﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using UniSelector.Models.ViewModel;
using UniSelector.Utility;

namespace UniSelector.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Institution")]
public class FacultyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public FacultyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(int id, int universityId)    
    {
        if (universityId is 0)
        {
            if (User.IsInRole("Institution"))
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                var university = _unitOfWork.University.Get(u => u.Email == userEmail);
                if (university == null)
                {
                    return NotFound("University not found");
                }
                universityId = university.Id;
            }
            else
            {
                return BadRequest();
            }
        }

        /*// If user is institution, verify they own this university
        if (User.IsInRole("Institution"))
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var university = _unitOfWork.University.Get(u => u.Id == universityId);
            if (university == null || university.Email != userEmail)
            {
                return Unauthorized();
            }
        }*/

        var facultyVm = new FacultyVM();

        InitPage(id, universityId , facultyVm);
       
        return View("Upsert", facultyVm);
    }
    
    

    [HttpPost]
    public IActionResult Upsert(FacultyVM facultyVm)
    {
        var factId = facultyVm.faculty.Id;
        var uniId = facultyVm.faculty.UniversityId;

        // Verify user has permission
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
            InitPage(factId, uniId , facultyVm);
            return View("Upsert", facultyVm);
        }

        // Check for duplicates
        var uniFromDb = _unitOfWork.University.Get(u => u.Id== facultyVm.faculty.UniversityId, 
                includeProperties:"Faculties", isTracked: false);

        // For existing faculty (Update)
        if (factId is not 0)
        {
            var excludeCurFact = uniFromDb.Faculties.Where(f => f.Id != factId);
            if (excludeCurFact.Any(faculty => faculty.StandardFacultyId == facultyVm.faculty.StandardFacultyId))
            {
                ModelState.AddModelError("", "The faculty already exists");
                InitPage(factId, uniId , facultyVm);
                return View("Upsert", facultyVm);
            }
        }

        // For new faculty (Create)
        if (factId is 0 && uniFromDb.Faculties.Any(faculty => faculty.StandardFacultyId == facultyVm.faculty.StandardFacultyId))
        {
            ModelState.AddModelError("", "The faculty already exists");
            InitPage(factId, uniId , facultyVm);
            return View("Upsert", facultyVm);
        }

        if (factId is 0)
        {
            _unitOfWork.Faculty.Add(facultyVm.faculty);
        }
        else
        {
            _unitOfWork.Faculty.Update(facultyVm.faculty);
        }
        _unitOfWork.Save();
        TempData["success"] = (facultyVm.faculty.Id is 0) ? "Faculty added Successfully" : "Faculty Updated Successfully";
        return RedirectToAction(nameof(Index), new {universityId = uniId});
    }

    public IActionResult Delete(int? id, int uniId)
    {
        if (id is null or 0)
            return BadRequest();
        var faculty = _unitOfWork.Faculty.Get(f => f.Id == id);
        _unitOfWork.Faculty.Remove(faculty);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index), new {universityId = uniId});
    }

    private void FillSelectionData(FacultyVM facultyVm)
    {
        var standardFaculties = _unitOfWork.StandardFaculty.GetAll();
        facultyVm.facultyList = standardFaculties.Select(sf => new SelectListItem
        {
            Value = sf.Id.ToString(),
            Text = sf.CombinedName
        });
    }

    private void InitPage(int id, int universityId, FacultyVM facultyVm)
    {
        var faculties = _unitOfWork.Faculty.GetAll(f => f.UniversityId == universityId, 
            includeProperties: "University,StandardFaculty").ToList();
        var university = _unitOfWork.University.Get(u => u.Id == universityId);
        facultyVm.UniversityName = university.Name;
        facultyVm.Faculties = faculties;
        facultyVm.faculty = id is 0 ? new Faculty() : _unitOfWork.Faculty.Get(f => f.Id == id);
        facultyVm.faculty.UniversityId = universityId;
        FillSelectionData(facultyVm);
    }

    #region API CALLS

    [HttpGet]
    public JsonResult GetMajors(int facultyId)
    {
        if (facultyId is 0) return Json("");

        var majors = _unitOfWork.Major.GetAll(m => m.FacultyId == facultyId);
        return Json(majors);
    }

    #endregion
}