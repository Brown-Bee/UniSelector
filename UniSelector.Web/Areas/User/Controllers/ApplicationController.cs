using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UniSelector.Models.Enums;

namespace UniSelector.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ApplicationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Apply(int universityId, int facultyId, int majorId, string uniEmail)
        {
            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null) return NotFound("User not found");
            
            var user = _unitOfWork.ApplicationUser.Get(a => a.Id == userId);
            var university = _unitOfWork.University.Get(u => u.Id == universityId, includeProperties: "Faculties");
            var faculty = _unitOfWork.Faculty.Get(f => f.Id == facultyId, includeProperties: "Majors,StandardFaculty");
            var major = _unitOfWork.Major.Get(m => m.Id == majorId, includeProperties: "StandardMajor");

            // Create application view model
            var applicationVm = new ApplicationVM
            {
                ApplicationUser = user,
                Application = new()
                {
                    UniversityId = universityId,
                    FacultyId = facultyId,
                    MajorId = majorId,
                    UserId = user.Id,
                    UniEmail = uniEmail,
                    University = university,
                    Faculty = faculty,
                    Major = major
                },
                universityName = university.Name,
            };
            return View(applicationVm);
        }

        // POST: Submit application with documents
        [HttpPost]
        public IActionResult Apply(ApplicationVM applicationVm, bool saveDraft = false)
        {
            if (!ModelState.IsValid) 
                return View(applicationVm); 
            if (!saveDraft && !IsEligible(applicationVm))
            {
                return View(applicationVm);
            }

            HandleDocumentUploads(applicationVm);

            applicationVm.Application.Status = saveDraft ? ApplicationStatus.Draft.ToString() : ApplicationStatus.Posted.ToString();
            if (applicationVm.Application.Id == 0)
            {
                _unitOfWork.Application.Add(applicationVm.Application);
            }
            else
            {
                _unitOfWork.Application.Update(applicationVm.Application);
            }

            _unitOfWork.Save();

            TempData["success"] = saveDraft ?
                "Application saved as draft" :
                "Application submitted successfully";

            return RedirectToAction(nameof(MyApplications));
        }
        
        private bool IsEligible(ApplicationVM applicationVm)
        {
            var user = applicationVm.ApplicationUser;
            var application = applicationVm.Application;
            
            var major = _unitOfWork.Major
                .Get(m => m.Id == application.MajorId, includeProperties: "StandardMajor");
            var standardMajor = major.StandardMajor;
            if (standardMajor is null) return false;

            bool highSchoolType = false, grade = false, minimumIelts = true, minimumToefl = true;
            
            if (user.HighSchoolType == standardMajor.HighSchoolPath ||
                standardMajor.HighSchoolPath == "Both") highSchoolType = true;

            if (user.Grade >= major.MinimumGrade) grade = true;
            
            if (major.MinimumIELTS.HasValue && user.IELTS < major.MinimumIELTS) minimumIelts = false;
            
            if (major.MinimumTOEFL.HasValue && user.TOEFL < major.MinimumTOEFL) minimumToefl = false;

            if (!highSchoolType)
            {
                ModelState.AddModelError("", $"Your high school path ({user.HighSchoolType}) does not match the required path ({standardMajor.HighSchoolPath}) for this major");
                return false;
            }

            if (!grade)
            {
                ModelState.AddModelError("", $"Your grade ({user.Grade}%) is below the minimum required grade ({major.MinimumGrade}%) for this major");
                return false;
            }

            if (!minimumIelts)
            {
                ModelState.AddModelError("", $"Your IELTS score ({user.IELTS}) is below the minimum required score ({major.MinimumIELTS}) for this major");
                return false;
            }

            if (!minimumToefl)
            {
                ModelState.AddModelError("", $"Your TOEFL score ({user.TOEFL}) is below the minimum required score ({major.MinimumTOEFL}) for this major");
                return false;
            }
            return true;
        }
        
        private void HandleDocumentUploads(ApplicationVM applicationVm)
        {
            
            var application = applicationVm.Application;
            
            if (!string.IsNullOrEmpty(application.CivilIdPath))
            {
                DocumentHelper.DeleteDocument(application.CivilIdPath, _webHostEnvironment);
            }

            // Upload new file
            applicationVm.Application.CivilIdPath =
                DocumentHelper.UploadDocument(applicationVm.CivilIdFile, "CivilId", _webHostEnvironment);

            if (!string.IsNullOrEmpty(applicationVm.Application.PassportPath))
            {
                DocumentHelper.DeleteDocument(applicationVm.Application.PassportPath, _webHostEnvironment);
            }

            application.PassportPath =
                DocumentHelper.UploadDocument(applicationVm.PassportFile, "Passport", _webHostEnvironment);

            if (!string.IsNullOrEmpty(applicationVm.Application.HighSchoolCertificatePath))
            {
                DocumentHelper.DeleteDocument(applicationVm.Application.HighSchoolCertificatePath, _webHostEnvironment);
            }

            // Upload new file
            application.HighSchoolCertificatePath =
                DocumentHelper.UploadDocument(applicationVm.HighSchoolCertificateFile,
                    "Certificate",
                    _webHostEnvironment);
            applicationVm.Application = application;
        }

        // GET: User's applications list
        public IActionResult MyApplications()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applications = _unitOfWork.Application.GetUserApplications(userId);
            return View(applications.ToList());
        }

        // POST: Delete document
        [HttpPost]
        public IActionResult DeleteDocument(int applicationId, string documentType)
        {
            var application = _unitOfWork.Application.Get(a => a.Id == applicationId);
            if (application == null)
                return Json(new { success = false });

            bool success = false;
            switch (documentType.ToLower())
            {
                case "civilid":
                    success = DocumentHelper.DeleteDocument(application.CivilIdPath, _webHostEnvironment);
                    if (success) application.CivilIdPath = null;
                    break;
                case "passport":
                    success = DocumentHelper.DeleteDocument(application.PassportPath, _webHostEnvironment);
                    if (success) application.PassportPath = null;
                    break;
                case "certificate":
                    success = DocumentHelper.DeleteDocument(application.HighSchoolCertificatePath, _webHostEnvironment);
                    if (success) application.HighSchoolCertificatePath = null;
                    break;
            }

            if (success)
            {
                _unitOfWork.Application.Update(application);
                _unitOfWork.Save();
            }

            return Json(new { success });
        }
    }
}