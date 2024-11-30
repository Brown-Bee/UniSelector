﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using System.Threading.Tasks;

namespace UniSelector.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ApplicationUser> objApplicationUser = _unitOfWork.ApplicationUser.GetAll().ToList();
            return View(objApplicationUser);
        }

        /*[HttpGet]
        public IActionResult GetAll()
        {
            var users = _unitOfWork.ApplicationUser.GetAll();
            var userList = users.Select(u => new {
                u.Id,
                u.Email,
                u.Name,
                u.Address,
                u.Grade,
                u.BirthDate,
                u.Nationality,
                u.PlaceOfBirth,
                u.HighSchoolGraduationYear
            });
            return Json(new { data = userList });
        }*/

        public IActionResult Upsert(string id)
        {
            var user =  _unitOfWork.ApplicationUser.Get(a => a.Id == id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid) return View(applicationUser);
            var existingUser =  _unitOfWork.ApplicationUser.Get(a => a.Id == applicationUser.Id);

            // Civil ID Information
            existingUser.CivilID = applicationUser.CivilID;
            existingUser.CivilIDExpiryDate = applicationUser.CivilIDExpiryDate;
            //Personal Information
            existingUser.Name = applicationUser.Name;
            existingUser.Email = applicationUser.Email;
            existingUser.UserName = applicationUser.Email; // Update UserName if it's based on Email
            existingUser.Gender = applicationUser.Gender;
            existingUser.MaritalStatus = applicationUser.MaritalStatus;
            //Additional Information
            existingUser.Nationality = applicationUser.Nationality;
            existingUser.MothersNationality = applicationUser.MothersNationality;
            existingUser.BirthDate = applicationUser.BirthDate;
            existingUser.PlaceOfBirth = applicationUser.PlaceOfBirth;
            //Address Information
            existingUser.Address = applicationUser.Address;
            //Academic Information
            existingUser.HighSchoolType = applicationUser.HighSchoolType;
            existingUser.IsPublicSchool = applicationUser.IsPublicSchool;
            existingUser.Grade = applicationUser.Grade;
            existingUser.HighSchoolGraduationYear = applicationUser.HighSchoolGraduationYear;
            //Test Scores
            existingUser.IELTS = applicationUser.IELTS;
            existingUser.TOEFL = applicationUser.TOEFL;
            existingUser.HasAptitudeTest = applicationUser.HasAptitudeTest;

            var result =  _unitOfWork.ApplicationUser.Update(existingUser);
            if (result)
            {
                _unitOfWork.Save();
                TempData["success"] = "User updated successfully";
                return RedirectToAction(nameof(Index));
            }
            _unitOfWork.Save();
            return View(applicationUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            /*var user = await _unitOfWork.ApplicationUser.Get(a => a.Id == id);
            if (user == null)
            {*/
                return Json(new { success = false, message = "Error while deleting" });
            /*}*/

            /*var result = await _unitOfWork.ApplicationUser.DeleteUser(user);
            if (result.Succeeded)
            {
                return Json(new { success = true, message = "User deleted successfully" });
            }*/
           // return Json(new { success = false, message = "Error while deleting" });
        }
    }
}