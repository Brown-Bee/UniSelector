using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class MajorController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MajorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(int id, int facultyId)
    {
        if (facultyId is 0)
        {
            return BadRequest();
        }

        var majorVm = new MajorVM();
        var majors = _unitOfWork.Major.GetAll(m => m.FacultyId == facultyId).ToList();
        var faculty = _unitOfWork.StandardFaculty.Get(f => f.Id == facultyId);
        majorVm.FacultyName = faculty.CombinedName;
        majorVm.Majors = majors;
        majorVm.Major = id is 0 ? new Major() : _unitOfWork.Major.Get(m => m.Id == id);
        majorVm.Major.FacultyId = facultyId;
        FillSelectionData(majorVm);
        return View("Upsert", majorVm);
    }

    [Authorize(Roles = "User,Admin")]
    public IActionResult GetMajorId(int facultyId)
    {
        var majors = _unitOfWork.Major.GetAll(m => m.FacultyId == facultyId).ToList();
        return View(majors);
    }
    
    /*public IActionResult Upsert(int id)
    {
        var majorVm = new MajorVM
        {   
            Major = new(),
        };
        FillSelectionData(majorVm);

        if (id is 0)
        {
            return View(majorVm);
        }
        var major = _unitOfWork.Major.Get(m => m.Id == id);
        majorVm.Major = major;
        return View(majorVm);
    }*/

    [HttpPost]
    public IActionResult Upsert(MajorVM majorVm)
    {
        // Add server-side validation for required fields
        if (majorVm.Major.MinimumGrade <= 0)
        {
            ModelState.AddModelError("Major.MinimumGrade", "Minimum grade is required");
        }
        if (!ModelState.IsValid)
        {
            FillSelectionData(majorVm);
            return View("Upsert", majorVm);
        }

        if (majorVm.Major.Id is 0)
        {
            _unitOfWork.Major.Add(majorVm.Major);
        }
        else
        {
            _unitOfWork.Major.Update(majorVm.Major);
        }
        _unitOfWork.Save();
        TempData["success"] = "Major added Successfully";
        return RedirectToAction(nameof(Index), new {facultyId = majorVm.Major.FacultyId});
    }

    public IActionResult Delete(int? id, int facId)
    {
        if (id is null or 0)
            return BadRequest();
        var major = _unitOfWork.Major.Get(m => m.Id == id);
        _unitOfWork.Major.Remove(major);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index), new {facultyId = facId});
    }

    // Helper method for filling dropdown lists
    private void FillSelectionData(MajorVM majorVm)
    {
        // Add validation checks for required fields
        if (majorVm.Major.MinimumGrade < 0 || majorVm.Major.MinimumGrade > 100)
        {
            ModelState.AddModelError("Major.MinimumGrade", "Grade must be between 0 and 100");
        }
        
        // Get all standard faculties for the first dropdown
        var standardFaculties = _unitOfWork.StandardFaculty.GetAll();
        majorVm.StandardFaculties = standardFaculties.Select(sf => new SelectListItem
        {
            Value = sf.Id.ToString(),
            Text = sf.CombinedName
        }).ToList();
        
        var standardMajors = _unitOfWork.StandardMajor
            .GetAll(sm => sm.StandardFacultyId == majorVm.Major.FacultyId);
        
        majorVm.StandardMajors = standardMajors.Select(sm => new SelectListItem
        {
            Value = sm.Id.ToString(),
            Text = sm.CombinedName
        }).ToList();

        /*// If a faculty is selected (during edit or after validation error)
        if (majorVm.Major.FacultyId > 0)
        {
            // Get majors only for the selected faculty
            

            // Fill the majors dropdown
           
        }*/
    }

    #region API CALLS

    [HttpGet]
    public JsonResult GetStandardMajors(int facultyId)
    {
        if (facultyId is 0) return Json("");

        var standardMajors = _unitOfWork.StandardMajor
            .GetAll(sm => sm.StandardFacultyId == facultyId);
       return Json(standardMajors);
    }

    #endregion
}