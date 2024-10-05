using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.ApplicationUser.GetAllUsers();
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
        }

        public async Task<IActionResult> Upsert(string id)
        {
            var user = await _unitOfWork.ApplicationUser.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _unitOfWork.ApplicationUser.GetUserById(model.Id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                existingUser.Email = model.Email;
                existingUser.UserName = model.Email; // Update UserName if it's based on Email
                existingUser.Name = model.Name;
                existingUser.Address = model.Address;
                existingUser.Grade = model.Grade;
                existingUser.BirthDate = model.BirthDate;
                existingUser.Nationality = model.Nationality;
                existingUser.PlaceOfBirth = model.PlaceOfBirth;
                existingUser.HighSchoolGraduationYear = model.HighSchoolGraduationYear;

                var result = await _unitOfWork.ApplicationUser.UpdateUser(existingUser);
                if (result.Succeeded)
                {
                    TempData["success"] = "User updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _unitOfWork.ApplicationUser.GetUserById(id);
            if (user == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var result = await _unitOfWork.ApplicationUser.DeleteUser(user);
            if (result.Succeeded)
            {
                return Json(new { success = true, message = "User deleted successfully" });
            }
            return Json(new { success = false, message = "Error while deleting" });
        }
    }
}