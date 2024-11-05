using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.IdentityModel.Tokens;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class FacultyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public FacultyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var objFacultyList =
            _unitOfWork.Faculty.GetAll(includeProperties: "University,StandardFaculty").ToList();
        return View(objFacultyList);
    }

    public IActionResult Upsert(int? id)
    {
        var facultyVM = new FacultyVM
        {
            faculty = new Faculty(),
        };
        FillSelectionData(facultyVM);

        
        if (id is null or 0)
        {
            return View(facultyVM);
        }

        facultyVM.faculty = _unitOfWork.Faculty.Get(u => u.Id == id, includeProperties: "StandardFaculty");
        return View(facultyVM);
    }

    [HttpPost]
    public IActionResult Upsert(FacultyVM facultyVM)
    {
        if (!ModelState.IsValid)
        {
            FillSelectionData(facultyVM);
            return View(facultyVM);
        }
        if (facultyVM.faculty.Id == 0)
        {
            _unitOfWork.Faculty.Add(facultyVM.faculty);
        }
        else
        {
            _unitOfWork.Faculty.Update(facultyVM.faculty);
        }

        _unitOfWork.Save();
        TempData["success"] = "Faculty created successfully";
        return RedirectToAction("Index");


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
        TempData["success"] = "faculty deleted successfully";
        return RedirectToAction("Index", "faculty");
    }

    private void FillSelectionData(FacultyVM facultyVM)
    {
        facultyVM.facultyList = _unitOfWork.StandardFaculty.GetAll().Select(sf => new SelectListItem
        {
            Text = sf.CombinedName,
            Value = sf.Id.ToString()
        });
        facultyVM.UniversityList = _unitOfWork.University.GetAll().Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
    }

    #region API CALL

    [HttpGet]
    public JsonResult GetMajors(int facultyId)
    {
        var  majors = _unitOfWork.Major.GetAll(m => m.StandardFacultyId == facultyId);
        return Json(majors.ToList());
    }

    #endregion
    
}
