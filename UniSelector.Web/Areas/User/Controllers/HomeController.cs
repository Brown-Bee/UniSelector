using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;

namespace BulkyBookWeb.Areas.User.Controllers
{
    [Area(Constants.AreaUser)]
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
            /*IEnumerable<Product> ProductList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(ProductList);*/
            return RedirectToAction("UniversityView");
        }
        public IActionResult UniversityView(string searchString, int? facultyId, decimal? maxFees, int? maxRank)
        {
            IEnumerable<University> Universities = _unitOfWork.University.GetAll(includeProperties: "Faculties");

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                Universities = Universities.Where(u =>
                    u.Name.ToLower().Contains(searchString) ||
                    u.location.ToLower().Contains(searchString) ||
                    u.Description.ToLower().Contains(searchString) ||
                    u.Faculties.Any(f => f.StandardFaculty.CombinedName.ToLower().Contains(searchString)));
            }
            // Filter According to the Faculty
            if (facultyId.HasValue)
            {
                Universities = Universities.Where(u => u.Faculties.Any(f => f.Id == facultyId));
            }
            // Filter According to the AvaragePrice
            if (maxFees.HasValue)
            {
                Universities = Universities.Where(u => u.Faculties.Any(f => f.AveragePrice <= maxFees.Value));
            }
            // Filter According to the Rank in Kuwait
            if (maxRank.HasValue)
            {
                Universities = Universities.Where(u => u.KuwaitRank <= maxRank.Value);
            }
            ViewBag.Faculties = _unitOfWork.Faculty.GetAll().Select(f => new SelectListItem
            {
                Text = f.StandardFaculty.CombinedName,
                Value = f.Id.ToString()
            });
            ViewBag.CurrentSearchString = searchString;
            ViewBag.CurrentFacultyId = facultyId;
            ViewBag.CurrentMaxFees = maxFees;
            ViewBag.CurrentMaxRank = maxRank;
            return View(Universities);
        }
        public IActionResult UniDetails(int UniversityId)
        {
            University university = _unitOfWork.University.GetWithGalleryImages(UniversityId);
            return View(university);
        }
        public IActionResult Details(int ProductId)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == ProductId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
