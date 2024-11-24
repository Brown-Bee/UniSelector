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


        /*// GET: Display application form
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
        }*/
        // GET: Display application form
        public async Task<IActionResult> Apply(int universityId, int facultyId, int majorId)
        {
            // Get current user
            var user = await _userManager.GetUserAsync(User);
            var major = _unitOfWork.Major.Get(m => m.Id == majorId, includeProperties: "StandardMajor");

            // Create application view model
            var applicationVm = new ApplicationVM
            {
                // Initialize with existing user data
                Name = user.Name,
                CivilID = user.CivilID,
                Gender = user.Gender,
                Nationality = user.Nationality,
                MothersNationality = user.MothersNationality,
                BirthDate = user.BirthDate,
                PlaceOfBirth = user.PlaceOfBirth,
                Address = user.Address,
                HighSchoolType = user.HighSchoolType,
                Grade = user.Grade,
                HighSchoolGraduationYear = user.HighSchoolGraduationYear,
                IELTS = user.IELTS,
                TOEFL = user.TOEFL,
                HasAptitudeTest = user.HasAptitudeTest,

                // Initialize application
                Application = new()
                {
                    UniversityId = universityId,
                    FacultyId = facultyId,
                    MajorId = majorId,
                    UserId = user.Id,
                    ApplicationDate = DateTime.Now,
                    Status = "Pending",
                    IsDraft = true
                }
            };

            // Validate requirements
            if (major != null)
            {
                // Check high school type requirement
                applicationVm.MeetsTypeRequirement = major.StandardMajor.HighSchoolPath == "Both" ||
                                                   major.StandardMajor.HighSchoolPath == applicationVm.HighSchoolType;

                // Check grade requirement
                applicationVm.MeetsGradeRequirement = applicationVm.Grade >= major.MinimumGrade;

                // Check language requirement
                applicationVm.MeetsLanguageRequirement = (!major.MinimumIELTS.HasValue || applicationVm.IELTS >= major.MinimumIELTS) &&
                                                       (!major.MinimumTOEFL.HasValue || applicationVm.TOEFL >= major.MinimumTOEFL);

                // Generate warnings
                var warnings = new List<string>();

                if (!applicationVm.MeetsTypeRequirement)
                    warnings.Add($"This major requires {major.StandardMajor.HighSchoolPath} high school path.");

                if (!applicationVm.MeetsGradeRequirement)
                    warnings.Add($"Minimum grade required is {major.MinimumGrade}%.");

                if (!applicationVm.MeetsLanguageRequirement)
                {
                    if (major.MinimumIELTS.HasValue)
                        warnings.Add($"Minimum IELTS score required is {major.MinimumIELTS}.");
                    if (major.MinimumTOEFL.HasValue)
                        warnings.Add($"Minimum TOEFL score required is {major.MinimumTOEFL}.");
                }

                applicationVm.ValidationWarnings = warnings.ToArray();
            }

            return View(applicationVm);
        }

        // POST: Submit application with documents
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(ApplicationVM applicationVM, bool saveDraft = false)
        {
            var user = await _userManager.GetUserAsync(User);
            var major = _unitOfWork.Major.Get(m => m.Id == applicationVM.Application.MajorId,
                                                 includeProperties: "StandardMajor");

            if (!saveDraft)
            {
                // Validate requirements if not saving as draft
                if (!ValidateRequirements(applicationVM, major))
                {
                    // Re-populate warnings
                    SetValidationWarnings(applicationVM, major);
                    return View(applicationVM);
                }
            }

            // Update user profile
            await UpdateUserProfile(user, applicationVM);

            // Handle document uploads
            HandleDocumentUploads(applicationVM);

            // Set application status
            applicationVM.Application.IsDraft = saveDraft;
            applicationVM.Application.Status = saveDraft ? "Draft" : "Pending";

            if (applicationVM.Application.Id == 0)
            {
                _unitOfWork.Application.Add(applicationVM.Application);
            }
            else
            {
                _unitOfWork.Application.Update(applicationVM.Application);
            }

            _unitOfWork.Save();

            TempData["success"] = saveDraft ?
                "Application saved as draft" :
                "Application submitted successfully";

            return RedirectToAction("MyApplications");
        }

        private async Task UpdateUserProfile(ApplicationUser user, ApplicationVM model)
        {
            user.Name = model.Name;
            user.CivilID = model.CivilID;
            user.Gender = model.Gender;
            user.Nationality = model.Nationality;
            user.MothersNationality = model.MothersNationality;
            user.BirthDate = model.BirthDate;
            user.PlaceOfBirth = model.PlaceOfBirth;
            user.Address = model.Address;
            user.HighSchoolType = model.HighSchoolType;
            user.Grade = model.Grade;
            user.HighSchoolGraduationYear = model.HighSchoolGraduationYear;
            user.IELTS = model.IELTS;
            user.TOEFL = model.TOEFL;
            user.HasAptitudeTest = model.HasAptitudeTest;

            await _userManager.UpdateAsync(user);
        }

        private bool ValidateRequirements(ApplicationVM model, Major major)
        {
            if (major == null) return false;

            return (major.StandardMajor.HighSchoolPath == "Both" ||
                    major.StandardMajor.HighSchoolPath == model.HighSchoolType) &&
                   model.Grade >= major.MinimumGrade &&
                   (!major.MinimumIELTS.HasValue || model.IELTS >= major.MinimumIELTS) &&
                   (!major.MinimumTOEFL.HasValue || model.TOEFL >= major.MinimumTOEFL);
        }

        private void SetValidationWarnings(ApplicationVM model, Major major)
        {
            var warnings = new List<string>();

            // Check high school type
            if (major.StandardMajor.HighSchoolPath != "Both" &&
                major.StandardMajor.HighSchoolPath != model.HighSchoolType)
            {
                warnings.Add($"This major requires {major.StandardMajor.HighSchoolPath} high school path. Your path is {model.HighSchoolType}.");
            }

            // Check grade
            if (model.Grade < major.MinimumGrade)
            {
                warnings.Add($"Your grade ({model.Grade}%) is below the minimum required grade ({major.MinimumGrade}%).");
            }

            // Check IELTS if required
            if (major.MinimumIELTS.HasValue)
            {
                if (!model.IELTS.HasValue)
                {
                    warnings.Add($"IELTS score is required. Minimum score: {major.MinimumIELTS}");
                }
                else if (model.IELTS < major.MinimumIELTS)
                {
                    warnings.Add($"Your IELTS score ({model.IELTS}) is below the minimum required score ({major.MinimumIELTS}).");
                }
            }

            // Check TOEFL if required
            if (major.MinimumTOEFL.HasValue)
            {
                if (!model.TOEFL.HasValue)
                {
                    warnings.Add($"TOEFL score is required. Minimum score: {major.MinimumTOEFL}");
                }
                else if (model.TOEFL < major.MinimumTOEFL)
                {
                    warnings.Add($"Your TOEFL score ({model.TOEFL}) is below the minimum required score ({major.MinimumTOEFL}).");
                }
            }

            // Check Aptitude Test if required
            if (major.RequiresAptitudeTest && !model.HasAptitudeTest)
            {
                warnings.Add("Aptitude Test is required for this major.");
            }

            model.ValidationWarnings = warnings.ToArray();
        }

        private void HandleDocumentUploads(ApplicationVM model)
        {
            // Handle Civil ID upload
            if (model.CivilIdFile != null)
            {
                // Delete old file if exists
                if (!string.IsNullOrEmpty(model.Application.CivilIdPath))
                {
                    DocumentHelper.DeleteDocument(model.Application.CivilIdPath, _webHostEnvironment);
                }

                // Upload new file
                model.Application.CivilIdPath =
                    DocumentHelper.UploadDocument(model.CivilIdFile, "CivilId", _webHostEnvironment);
            }

            // Handle Passport upload
            if (model.PassportFile != null)
            {
                // Delete old file if exists
                if (!string.IsNullOrEmpty(model.Application.PassportPath))
                {
                    DocumentHelper.DeleteDocument(model.Application.PassportPath, _webHostEnvironment);
                }

                // Upload new file
                model.Application.PassportPath =
                    DocumentHelper.UploadDocument(model.PassportFile, "Passport", _webHostEnvironment);
            }

            // Handle High School Certificate upload
            if (model.HighSchoolCertificateFile != null)
            {
                // Delete old file if exists
                if (!string.IsNullOrEmpty(model.Application.HighSchoolCertificatePath))
                {
                    DocumentHelper.DeleteDocument(model.Application.HighSchoolCertificatePath, _webHostEnvironment);
                }

                // Upload new file
                model.Application.HighSchoolCertificatePath =
                    DocumentHelper.UploadDocument(model.HighSchoolCertificateFile,
                                               "Certificate",
                                               _webHostEnvironment);
            }
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