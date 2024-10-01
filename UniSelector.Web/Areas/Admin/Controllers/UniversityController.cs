using UniSelector.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UniversityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UniversityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
                return View(university);
            }
        }
        [HttpPost]
        public IActionResult Upsert(University university, IFormFile? file, List<IFormFile> galleryFiles)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
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
                    university.ImageUrl = @"\Images\University\" + fileName;
                }
                //--------------Gallery Functionality--------------\\
                if (galleryFiles != null && galleryFiles.Count > 0)
                {
                    string universityFolderName = university.Id == 0 ? Guid.NewGuid().ToString() : university.Id.ToString();
                    string galleryPath = Path.Combine(wwwRootPath, @"Images", "University", "Gallery", universityFolderName);

                    if (!Directory.Exists(galleryPath))
                    {
                        Directory.CreateDirectory(galleryPath);
                    }

                    foreach (var galleryFile in galleryFiles)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(galleryFile.FileName);
                        using (var fileStream = new FileStream(Path.Combine(galleryPath, fileName), FileMode.Create))
                        {
                            galleryFile.CopyTo(fileStream);
                        }
                        university.GalleryImages.Add(new GalleryImage { ImageUrl = Path.Combine(@"\Images", "University", "Gallery", universityFolderName, fileName) });
                    }
                }
                //-------------------------------------------------\\
                if (university.Id == 0)
                {
                    _unitOfWork.University.Add(university);
                    _unitOfWork.Save(); // Save to get the new university ID

                    // Rename the gallery folder with the new university ID
                    if (university.GalleryImages.Any())
                    {
                        string oldPath = Path.Combine(wwwRootPath, Path.GetDirectoryName(university.GalleryImages.First().ImageUrl));
                        string newPath = Path.Combine(wwwRootPath, @"Images", "University", "Gallery", university.Id.ToString());
                        
                        Directory.Move(oldPath, newPath);

                        // Update ImageUrl for each gallery image
                        foreach (var image in university.GalleryImages)
                        {
                            image.ImageUrl = image.ImageUrl.Replace(Path.GetFileName(oldPath), university.Id.ToString());
                        }
                        _unitOfWork.Save();
                    }
                }
                else
                {
                    _unitOfWork.University.Update(university);
                    _unitOfWork.Save();
                }
                
                TempData["success"] = "Universities " + (university.Id != 0 ? "Update" : "Create") + " successfully";
                return RedirectToAction("Index", "University");
            }
            return View(university);

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

            // Delete gallery folder
            string galleryPath = Path.Combine(wwwRootPath, "Images", "University", "Gallery", id.ToString());
            if (Directory.Exists(galleryPath))
            {
                Directory.Delete(galleryPath, true);
            }

            _unitOfWork.University.Remove(universityToBeDeleted);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        /*-----------------------------------Search Functionality-------------------------------------*/
        /*public IActionResult UniversityView(string searchString)
        {
            IEnumerable<University> universities;
            if (!string.IsNullOrEmpty(searchString))
            {
                universities = _unitOfWork.University.Search(searchString);
            }
            else
            {
                universities = _unitOfWork.University.GetAll();
            }
            return View(universities);
        }*/
    }
}