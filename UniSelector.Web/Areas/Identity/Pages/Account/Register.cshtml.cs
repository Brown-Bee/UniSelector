// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using UniSelector.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using UniSelector.Models;
using UniSelector.DataAccess.Repository.IRepository;

namespace UniSelector.Web.Areas.Identity.Pages.Account
{
    // Custom Validation for Graduation Year Attribute
    public class ValidGraduationYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;
                if (year < 1900 || year > currentYear)
                {
                    return new ValidationResult($"Graduation year must be between 1900 and {currentYear}.");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork )
        {
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Grade")]
            [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
            public float? Grade { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Birth Date")]
            public DateTime BirthDate { get; set; }

            [Display(Name = "Nationality")]
            public string Nationality { get; set; }

            [Display(Name = "Place of Birth")]
            public string PlaceOfBirth { get; set; }

            [Display(Name = "High School Graduation Year")]
            [ValidGraduationYear]
            public int? HighSchoolGraduationYear { get; set; }

            [Display(Name = "Role")]
            public string Role { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> RoleList { get; set; }
            /*public int? UniversityId { get; set; }*/
            [ValidateNever]
            public IEnumerable<SelectListItem> UniversityList { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!_roleManager.RoleExistsAsync(Constants.RoleUser).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.RoleUser)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.RoleAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.RoleUniversity)).GetAwaiter().GetResult();
            }
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // Populate the RileList inside the OnGetAsync method
            Input = new()
            {
                RoleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                }),
                UniversityList = _unitOfWork.University.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                /*if (Input.Role == Constants.RoleUniversity)
                {
                    user.UniversityId = Input.UniversityId;
                }*/


                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!string.IsNullOrEmpty(Input.Role))
                    {
                        await _userManager.AddToRoleAsync(user, Input.Role);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Constants.RoleUser);
                    }

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                var user = Activator.CreateInstance<ApplicationUser>();
                user.Name = Input.Name;
                user.Address = Input.Address; // Note: You might want to correct the spelling to "Address" in your ApplicationUser model
                user.Grade = Input.Grade;
                user.PhoneNumber = Input.PhoneNumber;
                user.BirthDate = Input.BirthDate;
                user.Nationality = Input.Nationality;
                user.PlaceOfBirth = Input.PlaceOfBirth;
                user.HighSchoolGraduationYear = Input.HighSchoolGraduationYear;
                return user;
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
