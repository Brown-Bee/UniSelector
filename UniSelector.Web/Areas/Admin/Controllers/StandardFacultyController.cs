using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Admin.Controllers
{
    [Area(Constants.AreaAdmin)]
    [Authorize(Roles = Constants.RoleAdmin)]
    public class StandardFacultyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StandardFacultyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<StandardFaculty> objStandardFacultyList = _unitOfWork.StandardFaculty.GetAll().ToList();
            return View(objStandardFacultyList);
        }

        public IActionResult Upsert(int? id)
        {
            StandardFaculty standardFaculty = new StandardFaculty();

            if (id == null || id == 0)
            {
                return View(standardFaculty);
            }
            else
            {
                standardFaculty = _unitOfWork.StandardFaculty.Get(u => u.Id == id);
                return View(standardFaculty);
            }
        }

        [HttpPost]
        public IActionResult Upsert(StandardFaculty standardFaculty)
        {
            if (ModelState.IsValid)
            {
                if (standardFaculty.Id == 0)
                {
                    _unitOfWork.StandardFaculty.Add(standardFaculty);
                }
                else
                {
                    _unitOfWork.StandardFaculty.Update(standardFaculty);
                }
                _unitOfWork.Save();
                TempData["success"] = "Standard faculty created successfully";
                return RedirectToAction("Index");
            }
            return View(standardFaculty);
        }

        public IActionResult Delete(int id)
        {
            var standardFacultyToBeDeleted = _unitOfWork.StandardFaculty.Get(u => u.Id == id);
            if (standardFacultyToBeDeleted == null)
            {
                return NotFound();
            }
            _unitOfWork.StandardFaculty.Remove(standardFacultyToBeDeleted);
            _unitOfWork.Save();
            TempData["success"] = "Standard faculty deleted successfully";
            return RedirectToAction("Index");
        }
    }
}