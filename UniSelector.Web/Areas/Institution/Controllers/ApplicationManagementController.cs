using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;

namespace UniSelector.Areas.Institution.Controllers
{
    [Area("Institution")]
    [Authorize(Roles = "Institution,User")]
    public class ApplicationManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public ApplicationManagementController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        // GET: List all applications for the university
        [Authorize(Roles = "Institution")]
        public IActionResult Index()
        {
            var uniEmail = User.FindFirstValue(ClaimTypes.Email);

            var applications = _unitOfWork.Application.GetUniversityApplications(uniEmail);
            return View(applications.ToList());
        }

        // Unified Details action
        public IActionResult Details(int id)
        {
            var application = _unitOfWork.Application.Get(a => a.Id == id,
                includeProperties: "User,Major.StandardMajor,Faculty.StandardFaculty,University");

            if (application == null) return NotFound();

            // Verify user has permission to view this application
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("User") && application.UserId != userId)
                return Forbid();

            if (User.IsInRole("Institution") && application.UniEmail != userEmail)
                return Forbid();

            return View(application);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Delete(int id)
        {
            var application = _unitOfWork.Application.Get(a => a.Id == id);
            if (application == null) return NotFound();

            // Verify user owns this application
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (application.UserId != userId) return Forbid();

            if (application.Response != "Pending")
                return BadRequest("Cannot cancel a processed application");

            _unitOfWork.Application.Remove(application);
            _unitOfWork.Save();

            TempData["success"] = "Application cancelled successfully";
            return RedirectToAction("MyApplications", "Application", new { area = "User" });
        }

        // POST: Update application status
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status, string? feedback)
        {
            // Get application with all needed details
            var application = _unitOfWork.Application.Get(a => a.Id == id,
                includeProperties: "User,University,Faculty.StandardFaculty,Major.StandardMajor");

            if (application == null) return NotFound();

            // Update status
            _unitOfWork.Application.UpdateStatus(id, status, feedback);
            _unitOfWork.Save();

            // Send email notification
            string emailBody = EmailTemplates.GetApplicationResponseEmail(
                application.User.Name,
                application.University.Name,
                application.Faculty.StandardFaculty.CombinedName,
                application.Major.StandardMajor.CombinedName,
                status,
                feedback
            );

            await _emailSender.SendEmailAsync(
                application.User.Email,
                $"Application {status} - {application.University.Name}",
                emailBody
            );

            return RedirectToAction(nameof(Index));
        }



        // Helper method to get university ID
        private int GetCurrentUniversityId()
        {
            var userName = User.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                return 0;

            // Get all universities and filter on client side
            var universities = _unitOfWork.University.GetAll().AsEnumerable();
            var university = universities.FirstOrDefault(u => u.Email == userName);
            return university?.Id ?? 0;
        }


    }
}