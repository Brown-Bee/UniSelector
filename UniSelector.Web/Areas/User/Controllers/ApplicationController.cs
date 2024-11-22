using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace UniSelector.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize] // Only logged in users can access
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


        // Helper method to get current user ID
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        // GET: Display application form
        public IActionResult Apply(int universityId, int facultyId, int majorId)
        {
            // Create new application with provided IDs
            var applicationVm = new ApplicationVM
            {
                Application = new()
                {
                    UniversityId = universityId,
                    FacultyId = facultyId,
                    MajorId = majorId,
                    UserId = GetCurrentUserId(), // Getting the current userId
                    ApplicationDate = DateTime.Now,
                    Status = "Pending"
                }
            };

            return View(applicationVm);
        }

        // POST: Submit application with documents
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply(ApplicationVM applicationVM)
        {
            if (ModelState.IsValid)
            {
                if (applicationVM.CivilIdFile != null)
                {
                    applicationVM.Application.CivilIdPath =
                        DocumentHelper.UploadDocument(applicationVM.CivilIdFile, "CivilId", _webHostEnvironment);
                }

                if (applicationVM.PassportFile != null)
                {
                    applicationVM.Application.PassportPath =
                        DocumentHelper.UploadDocument(applicationVM.PassportFile, "Passport", _webHostEnvironment);
                }

                if (applicationVM.HighSchoolCertificateFile != null)
                {
                    applicationVM.Application.HighSchoolCertificatePath =
                        DocumentHelper.UploadDocument(applicationVM.HighSchoolCertificateFile, "HighSchoolCertificate", _webHostEnvironment);
                }

                _unitOfWork.Application.Add(applicationVM.Application);
                _unitOfWork.Save();
                TempData["success"] = "Application submitted successfully";
                return RedirectToAction("MyApplications");
            }
            return View(applicationVM);
        }


        // GET: User's applications list
        public IActionResult MyApplications()
        {
            var userId = GetCurrentUserId();
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