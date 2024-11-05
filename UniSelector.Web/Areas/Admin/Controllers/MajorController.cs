using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniSelector.DataAccess.Repository.IRepository;
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

    public IActionResult Index(int? facultyId)
    {
        if (!facultyId.HasValue) 
            return View(_unitOfWork.Major.GetAll().ToList());
        var majors = _unitOfWork.Major.GetAll(m => m.StandardFacultyId == facultyId).ToList();
        return View(majors);
    }

    [Authorize(Roles = "User,Admin")]
    public IActionResult GetMajorId(int facultyId)
    {
        var majors = _unitOfWork.Major.GetAll(m => m.StandardFacultyId == facultyId).ToList();
        return View(majors);
    }

    public IActionResult Upsert(int id)
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
    }

    [HttpPost]
    public IActionResult Upsert(MajorVM majorVm)
    {
        if (!ModelState.IsValid)
        {
            FillSelectionData(majorVm);
            return View(majorVm);
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
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id is null or 0)
            return BadRequest();
        var major = _unitOfWork.Major.Get(m => m.Id == id);
        _unitOfWork.Major.Remove(major);
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
    }

    private void FillSelectionData(MajorVM majorVm)
    {
        var standardFaculties = _unitOfWork.StandardFaculty.GetAll();
        majorVm.StandardFaculties = standardFaculties.Select(sf => new SelectListItem
        {
            Value = sf.Id.ToString(),
            Text = sf.CombinedName
        }).ToList();
    }
}