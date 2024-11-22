using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Utility;

namespace UniSelector.Areas.Institution.Controllers
{
    [Area("Institution")]
    [Authorize(Roles = SD.RoleUniversity)]
    public class ApplicationManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: List all applications for the university
        public IActionResult Index()
        {
            var universityId = GetCurrentUniversityId();
            var applications = _unitOfWork.Application.GetUniversityApplications(universityId).ToList();
            return View(applications);
        }

        // GET: Application details
        public IActionResult Details(int id)
        {
            var application = _unitOfWork.Application.Get(a => a.Id == id,
                includeProperties: "User,Major,Faculty");
            return View(application);
        }

        // POST: Update application status
        [HttpPost]
        public IActionResult UpdateStatus(int id, string status, string? feedback)
        {
            _unitOfWork.Application.UpdateStatus(id, status, feedback);
            _unitOfWork.Save();
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