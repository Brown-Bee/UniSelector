using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;

namespace UniSelector.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,University")]
public class MajorController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MajorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [Authorize(Roles = "Admin")]
    public IActionResult Index(int majorId, int facultyId, int standardFactId, int universityId)
    {
        if (facultyId is 0)
        {
            return BadRequest();
        }
        // Verify ownership for University role
        if (User.IsInRole("University"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Email == userEmail);

            if (university == null || university.Id != universityId)
            {
                return BadRequest();
            }

            // Verify faculty belongs to this university
            var faculty = _unitOfWork.Faculty.Get(f => f.Id == facultyId && f.UniversityId == universityId);
            if (faculty == null)
            {
                return BadRequest();
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
        return View("Upsert", majorVm);
    }

    public IActionResult GetMajorId(int facultyId)
    {
        
        var majors = _unitOfWork.Major
            .GetAll(m => m.FacultyId == facultyId, includeProperties:"Faculty.University,StandardMajor").ToList();
        return View(majors);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Upsert(MajorVM majorVm)
    {
        // Verify ownership for University role
        if (User.IsInRole("University"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Email == userEmail);

            if (university == null || university.Id != majorVm.UniId)
            {
                return BadRequest();
            }

            // Verify faculty belongs to this university
            var faculty = _unitOfWork.Faculty.Get(f => f.Id == majorVm.Major.FacultyId && f.UniversityId == majorVm.UniId);
            if (faculty == null)
            {
                return BadRequest();
            }
        }

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
        // Only perform this check when adding a new major
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

    [Authorize(Roles = "Admin,University")]
    public IActionResult Delete(int majorId, int factId, int standFactId, int uniId)
    {
        // Verify ownership for University role
        if (User.IsInRole("University"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Email == userEmail);

            if (university == null || university.Id != uniId)
            {
                return BadRequest();
            }

            // Verify faculty belongs to this university
            var faculty = _unitOfWork.Faculty.Get(f => f.Id == factId && f.UniversityId == uniId);
            if (faculty == null)
            {
                return BadRequest();
            }
        }
        if (majorId is 0)
            return BadRequest();
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