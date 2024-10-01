using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_University)]
    public class FacultyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacultyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Faculty> objFacultyList = _unitOfWork.Faculty.GetAll(includeProperties: "University").ToList();
            return View(objFacultyList);
        }

        public IActionResult Upsert(int? id)
        {
            Faculty faculty = new Faculty();
            IEnumerable<SelectListItem> UniversityList = _unitOfWork.University
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            ViewBag.UniversityList = UniversityList;

            if (id == null || id == 0)
            {
                return View(faculty);
            }
            else
            {
                faculty = _unitOfWork.Faculty.Get(u => u.Id == id);
                return View(faculty);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                if (faculty.Id == 0)
                {
                    _unitOfWork.Faculty.Add(faculty);
                }
                else
                {
                    _unitOfWork.Faculty.Update(faculty);
                }
                _unitOfWork.Save();
                TempData["success"] = "Faculty created successfully";
                return RedirectToAction("Index", "Faculty");
            }
            ViewBag.UniversityList = _unitOfWork.University.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(faculty);
        }

        public IActionResult Delete(int id)
        {
            var facultyToBeDeleted = _unitOfWork.Faculty.Get(u => u.Id == id);
            if (facultyToBeDeleted == null)
            {
                return NotFound();
            }
            _unitOfWork.Faculty.Remove(facultyToBeDeleted);
            _unitOfWork.Save();
            TempData["success"] = "Faculty deleted successfully";
            return RedirectToAction("Index", "Faculty");
        }
    }
}
