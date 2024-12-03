using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace UniSelector.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagementController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            /*List<ApplicationUser> objApplicationUser = _unitOfWork.ApplicationUser.GetAll().ToList();
            return View(objApplicationUser);*/
            var users = _unitOfWork.ApplicationUser.GetAll().ToList();
            return View((users,_userManager));
        }

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

        public async Task<IActionResult> Delete(string id)
        {
            //Validate input
            var userToBeDeleted = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if (string.IsNullOrEmpty(userToBeDeleted.Id))
            {
                TempData["error"] = "Invalid user ID";
                return RedirectToAction(nameof(Index));
            }
            //Get The User
            var user = await _userManager.FindByIdAsync(userToBeDeleted.Id);
            if (user == null)
            {
                TempData["error"] = "User not found";
                return RedirectToAction(nameof(Index));
            }
            //Delete The User
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _unitOfWork.Save();
                TempData["success"] = "User deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            // If deletion failed
            TempData["error"] = "Failed to delete user: " +
                string.Join(", ", result.Errors.Select(e => e.Description));
            return RedirectToAction(nameof(Index));

        }
    }
}