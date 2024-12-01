using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        /*----------------- University Actions -----------------*/
        public IActionResult UniversityView(string searchString, int? facultyId, int? maxRank)
        {
            IEnumerable<University> universities = _unitOfWork.University.GetAll(includeProperties: "Faculties");

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                universities = universities.Where(u =>
                    u.Name.ToLower().Contains(searchString) ||
                    u.location.ToLower().Contains(searchString) ||
                    u.FullDescription.ToLower().Contains(searchString) ||
                    u.Faculties.Any(f => f.StandardFaculty.CombinedName.ToLower().Contains(searchString)));
            }
            // Filter According to the Faculty
            if (facultyId.HasValue)
            {
                universities = universities.Where(u => u.Faculties.Any(f => f.StandardFacultyId == facultyId));
            }

            // Filter According to the Major



            // Filter According to the Rank in Kuwait
            if (maxRank.HasValue)
            {
                universities = universities.Where(u => u.KuwaitRank <= maxRank.Value);
            }
            ViewBag.Faculties = _unitOfWork.StandardFaculty.GetAll().Select(sf => new SelectListItem
            {
                Text = sf.CombinedName,
                Value = sf.Id.ToString()
            });
            /*ViewBag.Majors = _unitOfWork.StandardMajor.GetAll().Select(sf => new SelectListItem
            {
                Text = sf.CombinedName,
                Value = sf.Id.ToString()
            });*/
            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentFacultyId = facultyId;
            ViewBag.CurrentMaxRank = maxRank;
            return View(universities);
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
