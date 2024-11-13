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

        public IActionResult Index()
        {
            List<StandardMajor> objStandardMajorList = _unitOfWork.StandardMajor
                .GetAll(includeProperties: "StandardFaculty").ToList();
            return View(objStandardMajorList);
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
            if (ModelState.IsValid)
            {
                if (standardMajorVM.StandardMajor.Id == 0)
                {
                    _unitOfWork.StandardMajor.Add(standardMajorVM.StandardMajor);
                }
                else
                {
                    _unitOfWork.StandardMajor.Update(standardMajorVM.StandardMajor);
                }
                _unitOfWork.Save();
                TempData["success"] = "Standard major created successfully";
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
    }
}