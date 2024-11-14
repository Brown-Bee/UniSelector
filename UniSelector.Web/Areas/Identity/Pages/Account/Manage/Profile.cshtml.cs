using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UniSelector.Models;

namespace UniSelector.Web.Areas.Identity.Pages.Account.Manage
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProfileModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Full Name")]
            public string Name { get; set; }

            [Display(Name = "Civil ID")]
            public string CivilID { get; set; }

            public string Gender { get; set; }

            [Display(Name = "Marital Status")]
            public string? MaritalStatus { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Date of Birth")]
            public DateTime? BirthDate { get; set; }

            [Display(Name = "Place of Birth")]
            public string? PlaceOfBirth { get; set; }

            public string? Nationality { get; set; }

            [Display(Name = "Mother's Nationality")]
            public string? MothersNationality { get; set; }

            public string? Address { get; set; }

            [Display(Name = "High School Type")]
            public string? HighSchoolType { get; set; }

            [Range(0, 100)]
            [Display(Name = "High School Grade")]
            public float? Grade { get; set; }

            [Display(Name = "High School Graduation Year")]
            [Range(1900, 2024)]
            public int? HighSchoolGraduationYear { get; set; }

            [Display(Name = "Is Public School")]
            public bool IsPublicSchool { get; set; }

            [Display(Name = "Has 4 Years Experience")]
            public bool HasFourYearExperience { get; set; }

            [Display(Name = "Civil ID Expiry Date")]
            [DataType(DataType.Date)]
            public DateTime? CivilIDExpiryDate { get; set; }

            [Range(0, 9)]
            [Display(Name = "IELTS Score")]
            public float? IELTS { get; set; }

            [Range(0, 120)]
            [Display(Name = "TOEFL Score")]
            public float? TOEFL { get; set; }

            [Display(Name = "Has Aptitude Test")]
            public bool HasAptitudeTest { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            Username = userName;

            Input = new InputModel
            {
                // Load all properties
                Name = user.Name,
                CivilID = user.CivilID,
                Gender = user.Gender,
                MaritalStatus = user.MaritalStatus,
                BirthDate = user.BirthDate,
                PlaceOfBirth = user.PlaceOfBirth,
                Nationality = user.Nationality,
                MothersNationality = user.MothersNationality,
                Address = user.Address,
                HighSchoolType = user.HighSchoolType,
                Grade = user.Grade,
                HighSchoolGraduationYear = user.HighSchoolGraduationYear,
                IsPublicSchool = user.IsPublicSchool,
                HasFourYearExperience = user.HasFourYearExperience,
                CivilIDExpiryDate = user.CivilIDExpiryDate,
                IELTS = user.IELTS,
                TOEFL = user.TOEFL,
                HasAptitudeTest = user.HasAptitudeTest
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            // Update all properties
            user.Name = Input.Name;
            user.CivilID = Input.CivilID;
            user.Gender = Input.Gender;
            user.MaritalStatus = Input.MaritalStatus;
            user.BirthDate = Input.BirthDate;
            user.PlaceOfBirth = Input.PlaceOfBirth;
            user.Nationality = Input.Nationality;
            user.MothersNationality = Input.MothersNationality;
            user.Address = Input.Address;
            user.HighSchoolType = Input.HighSchoolType;
            user.Grade = Input.Grade;
            user.HighSchoolGraduationYear = Input.HighSchoolGraduationYear;
            user.IsPublicSchool = Input.IsPublicSchool;
            user.HasFourYearExperience = Input.HasFourYearExperience;
            user.CivilIDExpiryDate = Input.CivilIDExpiryDate;
            user.IELTS = Input.IELTS;
            user.TOEFL = Input.TOEFL;
            user.HasAptitudeTest = Input.HasAptitudeTest;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
