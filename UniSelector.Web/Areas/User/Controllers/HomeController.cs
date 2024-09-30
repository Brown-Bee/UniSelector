using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace BulkyBookWeb.Areas.User.Controllers
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
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }
        public IActionResult UniversityView()
        {
            IEnumerable<University> objUniversityList = _unitOfWork.University.GetAll().ToList();
            return View(objUniversityList);
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
