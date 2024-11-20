using System.Text;
using System.Text.Encodings.Web;
using Humanizer;
using UniSelector.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using UniSelector.DataAccess.Data;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.Web.Areas.Admin.Controllers
{    
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UniversityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public UniversityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, 
                ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            List<University> objUniversityList = _unitOfWork.University.GetAll().ToList();
            return View(objUniversityList);
        }

        public IActionResult Upsert(int? Id)
        {
            University university = new();
            if (Id == null || Id == 0)
            { //Create
                return View(university);
            }
            else
            { // Update
                university = _unitOfWork.University.Get(u => u.Id == Id, includeProperties: "Faculties");
                if (university == null)
                {
                    return NotFound();
                }
                return View(university);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(University university, IFormFile? file)
        {
            if (!ModelState.IsValid) return View(university);
            
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string universityPath = Path.Combine(wwwRootPath, @"Images\University");

                if (!string.IsNullOrEmpty(university.ImageUrl))
                {
                    string oldImagePath = Path.Combine(wwwRootPath, university.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(universityPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                university.ImageUrl = SD.UniversityImagePath + fileName;
            }                
            if (university.Id == 0)
            {
                _unitOfWork.University.Add(university);
                _unitOfWork.Save(); // Save to get the new university ID
            }
            else
            {
                _unitOfWork.University.Update(university);
                _unitOfWork.Save();
            }

            TempData["success"] = "Universities " + (university.Id != 0 ? "Update" : "Create") + " successfully";

            var email = university.Email;
            var institution = await _userManager.FindByEmailAsync(email);
            if (institution is null)
            {
                institution = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Name = university.Name,
                    PhoneNumber = university.PhoneNumber
                };

                var result = await _userManager.CreateAsync(institution, $"{university.Name}X123#");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(institution, SD.RoleUniversity);
                    
                    var code = await _userManager.GeneratePasswordResetTokenAsync(institution);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    
                    var resetPasswordUrl = Url.Page(
                        "/Account/ResetPassword",
                        null,
                        new { area = "Identity", code, email = institution.Email },
                        Request.Scheme);

                    await SendWelcomeEmailAsync(university.Name, email, resetPasswordUrl);
                    
                    return RedirectToAction("Index", "University");
                }

                // Log the error
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error creating admin user: {error.Description}");
                }
            }
            return View(university);
        }
        
        
        public async Task SendWelcomeEmailAsync(string Name, string email, string? resetPasswordUrl)
        {

            var subject = "Welcome To Our Company";
            var message = $"""
                           
                                   <!DOCTYPE html>
                                   <html>
                                       <head>
                                           <meta charset="UTF-8">
                                       </head>
                                       <body>
                                           <p style="margin-bottom: 20px;">Dear {Name},</p>
                                           
                                           <p style="margin-bottom: 20px;">Welcome to our company! Your account has been successfully created.</p>
                                           
                                           <p style="margin-bottom: 20px;">Your login credentials are:</p>
                                           <p>Username: {email}</p>
                                           <p style="margin-bottom: 20px;">
                                           
                                                You can set your password by clicking on <a href='{HtmlEncoder.Default.Encode(resetPasswordUrl)}'>Set Password</a>
                                           </p>
                                           <p style="margin-bottom: 20px;">If you have any questions or need assistance, please don't hesitate to contact our support team.</p>
                                           
                                           <p>Best regards,</p>
                                           <p>System Team</p>
                                       </body>
                                   </html>
                           """;

            await _emailSender.SendEmailAsync(email, subject, message);
        }


        public IActionResult Delete(int id)
        {
            var universityToBeDeleted = _unitOfWork.University.Get(u => u.Id == id);
            if (universityToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            // Delete main image
            if (!string.IsNullOrEmpty(universityToBeDeleted.ImageUrl))
            {
                var oldImagePath = Path.Combine(wwwRootPath, universityToBeDeleted.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }            

            _unitOfWork.University.Remove(universityToBeDeleted);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var universities = _unitOfWork.University.GetAll().Select(u => new {
                u.Id,
                u.Name,
                u.type,
                u.location,
                u.KuwaitRank,
            });
            return Json(new { data = universities });
        }

    }
}