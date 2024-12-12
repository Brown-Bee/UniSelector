using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniSelector.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize]
public class MajorController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MajorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [Authorize(Roles = "Admin,Institution")]
    public IActionResult Index(int majorId, int facultyId, int standardFactId, int universityId)
    {
        if (facultyId is 0) 
        {
            return BadRequest();
        }

        // Check if user is institution and verify ownership
        if (User.IsInRole("Institution"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Id == universityId);

            if (university == null || university.Email != userEmail)
            {
                return Unauthorized();
            }
        }

        var majorVm = new MajorVM
        {
            
            Major = new Major
            {
                Id = majorId
            }
        };
        InitPage(facultyId, standardFactId, universityId, majorVm);
        if (majorId != 0)
        {
            ViewBag.TotalApplications = _unitOfWork.Major.TotalApplications(majorId);
            ViewBag.AcceptanceRate = _unitOfWork.Major.GetAcceptanceRate(majorId);
        }
        return View("Upsert", majorVm);
    }

    public IActionResult GetMajorId(int facultyId)
    {
        
        var majors = _unitOfWork.Major
            .GetAll(m => m.FacultyId == facultyId, includeProperties:"Faculty.University,StandardMajor").ToList();
        return View(majors);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Institution")]
    public IActionResult Upsert(MajorVM majorVm)
    {
        var uniId = majorVm.UniId;
        var factId = majorVm.Major.FacultyId;
        var standFactId = majorVm.StandardFacultyId;
        var standMajorId = majorVm.Major.StandardMajorId;

        // Verify ownership for institution users
        if (User.IsInRole("Institution"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Id == uniId);

            if (university == null || university.Email != userEmail)
            {
                return Unauthorized();
            }
        }

        if (!ModelState.IsValid)
        {
            InitPage(factId, standFactId, uniId, majorVm);
            return View("Upsert", majorVm);
        }

        // Get faculty to check for duplicate majors
        var facultyFromDb = _unitOfWork.Faculty.Get(f => f.StandardFacultyId == majorVm.StandardFacultyId  
           && f.UniversityId == majorVm.UniId, includeProperties:"Majors"                            
        );

        // Check for duplicates when adding new major
        if (majorVm.Major.Id == 0)
        {
            foreach (var major in facultyFromDb.Majors)
            {
                if (major.StandardMajorId == standMajorId)
                {
                    ModelState.AddModelError("", "The Major already exists");
                    InitPage(factId, standFactId, uniId, majorVm);
                    return View("Upsert", majorVm);
                }
            }
        }

        // Add or Update major
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
    
    [Authorize(Roles = "Admin,Institution")]
    public IActionResult Delete(int majorId, int factId, int standFactId, int uniId)
    {       
        if (majorId == 0)
            return BadRequest();

        // Verify ownership for institution users
        if (User.IsInRole("Institution"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Id == uniId);

            if (university == null || university.Email != userEmail)
            {
                return Unauthorized();
            }
        }

        var major = _unitOfWork.Major.Get(m => m.Id == majorId);
        _unitOfWork.Major.Remove(major);
        _unitOfWork.Save();
        return RedirectToAction("Index", new {facultyId = factId, standardFactId = standFactId, universityId = uniId});
    }

    [Authorize(Roles = "Admin,User")]
    public IActionResult DetailsById(int majorId)
    {
        var majors = _unitOfWork.Major.Get(m => m.Id == majorId, 
                includeProperties:"Faculty.StandardFaculty,StandardMajor");
        ViewBag.AcceptanceRate = _unitOfWork.Major.GetAcceptanceRate(majorId);
        ViewBag.RejectionRate = _unitOfWork.Major.GetRejectionRate(majorId);
        ViewBag.TotalApplications = _unitOfWork.Major.TotalApplications(majorId);
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
    [Authorize(Roles = "Admin")]
    public JsonResult GetStandardMajors(int facultyId)
    {
        if (facultyId is 0) return Json("");

        var standardMajors = _unitOfWork.StandardMajor
            .GetAll(sm => sm.StandardFacultyId == facultyId);
       return Json(standardMajors);
    }
    
    #endregion
}