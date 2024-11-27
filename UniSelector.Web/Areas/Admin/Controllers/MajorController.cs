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

    public IActionResult Index(int majorId, int facultyId, int standardFactId, int universityId)
    {
        if (facultyId is 0)
        {
            return BadRequest();
        }
        
        var majorVm = new MajorVM
        {
            
            Major = new Major
            {
                Id = majorId
            }
        };
        InitPage(facultyId, standardFactId, universityId, majorVm);
        
      
        return View("Upsert", majorVm);
    }

    [Authorize(Roles = "User,Admin")]
    public IActionResult GetMajorId(int facultyId)
    {
        var majors = _unitOfWork.Major.GetAll(m => m.FacultyId == facultyId, includeProperties:"Faculty,StandardMajor").ToList();
        return View(majors);
    }

    [HttpPost]
    public IActionResult Upsert(MajorVM majorVm)
    {
        var uniId = majorVm.UniId;
        var factId = majorVm.Major.FacultyId;
        var standFactId = majorVm.StandardFacultyId;
        var standMajorId = majorVm.Major.StandardMajorId;
        if (!ModelState.IsValid)
        {
            InitPage(factId, standFactId, uniId, majorVm);
            return View("Upsert", majorVm);
        }
        var facultyFromDb = _unitOfWork.Faculty.Get(f => f.StandardFacultyId == majorVm.StandardFacultyId  
           && f.UniversityId == majorVm.UniId, includeProperties:"Majors"                            
        );
        foreach (var major in facultyFromDb.Majors)
        {
            if (major.StandardMajorId == standMajorId)
            {
                ModelState.AddModelError("", "The Major already exists");
                InitPage(factId, standFactId, uniId, majorVm);
                return View("Upsert", majorVm);
            }
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
        TempData["success"] = (majorVm.Major.Id is 0) ? "Major added Successfully" : "Major Updated Successfully";
        InitPage(factId, standFactId, uniId, majorVm);
        return RedirectToAction("Index", new {facultyId = factId, standardFactId = standFactId, universityId = uniId});
        
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

    [Authorize]
    public IActionResult DetailsById(int majorId)
    {
        var majors = _unitOfWork.Major.Get(m => m.Id == majorId, 
                includeProperties:"Faculty.StandardFaculty,StandardMajor");
        return View(majors);
    }

    // Helper method for filling dropdown lists
    private void FillSelectionData(MajorVM majorVm, int standardFactId)
    {
      
        // Get all standard faculties for the first dropdown
        var standardFaculties = _unitOfWork.StandardFaculty.GetAll();
        majorVm.StandardFaculties = standardFaculties.Select(sf => new SelectListItem
        {
            Value = sf.Id.ToString(),
            Text = sf.CombinedName
        }).ToList();
        
        var standardMajors = _unitOfWork.StandardMajor
            .GetAll(sm => sm.StandardFacultyId == standardFactId);

        majorVm.StandardMajors = standardMajors.Select(sm => new SelectListItem
        {
            Value = sm.Id.ToString(),
            Text = sm.CombinedName
        }).ToList();
    }

    private void InitPage(int facultyId, int standardFactId, int uniId, MajorVM majorVm)
    {
        var majors = _unitOfWork.Major.GetAll(m => m.FacultyId == facultyId, includeProperties:"Faculty").ToList();
        var faculty = _unitOfWork.StandardFaculty.Get(f => f.Id == standardFactId);
        majorVm.FacultyName = faculty.CombinedName;
        majorVm.Majors = majors;
        majorVm.UniId = uniId;
        majorVm.StandardFacultyId = standardFactId;
        var majorId = majorVm.Major.Id;
        majorVm.Major = majorId is 0 ? new Major() : _unitOfWork.Major.Get(m => m.Id == majorId);
        majorVm.Major.FacultyId = facultyId;
        FillSelectionData(majorVm, standardFactId);        
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