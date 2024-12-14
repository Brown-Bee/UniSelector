using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;

namespace UniSelector.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var homeVM = new HomeViewModel
            {
                UniversityCount = _unitOfWork.University.GetAll().Count(),
                FacultyCount = _unitOfWork.Faculty.GetAll().Count(),
                MajorCount = _unitOfWork.Major.GetAll().Count(),
                StudentCount = _unitOfWork.ApplicationUser.GetAll().Count()
            };
            return View(homeVM);
        }

        /*----------------- University Actions -----------------*/
        public IActionResult UniversityView( int? facultyId)
        {

            IEnumerable<University> universities = _unitOfWork.University.GetAll(includeProperties: "Faculties");
            // Filter According to the Faculty
            if (facultyId.HasValue)
            {
                universities = universities.Where(u => u.Faculties.Any(f => f.StandardFacultyId == facultyId));
            }
            
            ViewBag.Faculties = _unitOfWork.StandardFaculty.GetAll().Select(sf => new SelectListItem
            {
                Text = sf.CombinedName,
                Value = sf.Id.ToString()
            });
            
            ViewBag.CurrentFacultyId = facultyId;
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            var uniVm = new UniVM
            {
                Universities = universities.ToList(),
                User = user
            };
            return View(uniVm);
        }
        public IActionResult UniDetails(int universityId)
        {
            University? university = _unitOfWork.University.GetUniversityWithFaculties(universityId);
            return View(university);
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet]
        public JsonResult GetMajorsByFaculty(int facultyId)
        {
            // Retrieve majors associated with the selected faculty
            var majors = _unitOfWork.StandardMajor.GetAll()
                .Where(m => m.StandardFacultyId == facultyId)
                .Select(m => new SelectListItem
                {
                    Text = m.CombinedName,
                    Value = m.Id.ToString()
                })
                .ToList();

            return Json(majors);
        }
        
        [HttpGet]
        public async Task<JsonResult> FilterUniversities([FromQuery] UniversityFilter filter)
        {
            var results = await _unitOfWork.University.FilterUniversities(filter);
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };
            return Json(results, jsonOptions);
        }
    }
}
