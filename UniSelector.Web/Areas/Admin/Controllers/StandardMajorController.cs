using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StandardMajorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StandardMajorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /*public IActionResult Index()
        {
            List<StandardMajor> objStandardMajorList = _unitOfWork.StandardMajor
                .GetAll(includeProperties: "StandardFaculty").ToList();
            return View(objStandardMajorList);
        }*/
        public IActionResult Index()
        {
            ViewBag.Faculties = _unitOfWork.StandardFaculty.GetAll()
                .Select(f => new SelectListItem
                {
                    Text = f.CombinedName,
                    Value = f.Id.ToString()
                });

            return View();
        }

        public IActionResult Upsert(int? id)
        {
            StandardMajorVM standardMajorVM = new()
            {
                StandardMajor = new(),
                StandardFacultyList = _unitOfWork.StandardFaculty.GetAll()
                    .Select(f => new SelectListItem
                    {
                        Text = f.CombinedName,
                        Value = f.Id.ToString()
                    })
            };

            if (id == null || id == 0)
            {
                return View(standardMajorVM);
            }

            standardMajorVM.StandardMajor = _unitOfWork.StandardMajor.Get(u => u.Id == id);
            return View(standardMajorVM);
        }

        [HttpPost]
        public IActionResult Upsert(StandardMajorVM standardMajorVM)
        {
            if (standardMajorVM.StandardMajor.StudyDuration <= 0 || standardMajorVM.StandardMajor.StudyDuration > 7)
            {
                ModelState.AddModelError("StandardMajor.StudyDuration", "Study duration must be between 1 and 7 years");
            }

            if (string.IsNullOrEmpty(standardMajorVM.StandardMajor.HighSchoolPath))
            {
                ModelState.AddModelError("StandardMajor.HighSchoolPath", "High school path is required");
            }


            if (ModelState.IsValid)
            {
                if (standardMajorVM.StandardMajor.Id == 0)
                {
                    _unitOfWork.StandardMajor.Add(standardMajorVM.StandardMajor);
                    TempData["success"] = "Standard major created successfully";
                }
                else
                {
                    _unitOfWork.StandardMajor.Update(standardMajorVM.StandardMajor);
                    TempData["success"] = "Standard major updated successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            standardMajorVM.StandardFacultyList = _unitOfWork.StandardFaculty.GetAll()
                .Select(f => new SelectListItem
                {
                    Text = f.CombinedName,
                    Value = f.Id.ToString()
                });
            return View(standardMajorVM);
        }

        public IActionResult Delete(int id)
        {
            var standardMajorToBeDeleted = _unitOfWork.StandardMajor.Get(u => u.Id == id);
            if (standardMajorToBeDeleted == null)
            {
                return NotFound();
            }
            _unitOfWork.StandardMajor.Remove(standardMajorToBeDeleted);
            _unitOfWork.Save();
            TempData["success"] = "Standard major deleted successfully";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var majors = _unitOfWork.StandardMajor
                .GetAll(includeProperties: "StandardFaculty")
                .Select(m => new {
                    id = m.Id,
                    name = m.CombinedName,
                    facultyName = m.StandardFaculty?.CombinedName,
                    studyDuration = m.StudyDuration,
                    highSchoolPath = m.HighSchoolPath
                });
            return Json(new { data = majors });
        }
    }
}