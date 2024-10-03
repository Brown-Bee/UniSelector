using UniSelector.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.Web.Areas.Admin.Controllers
{
    [Area(Constants.AreaAdmin)]
    [Authorize(Roles = Constants.RoleAdmin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Upsert(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return View(new Category());
            }
            else
            {
                Category? categoryFromDb2 = _unitOfWork.Category.Get(u => u.Id == Id);
                if (categoryFromDb2 == null)
                {
                    return NotFound();
                }
                return View(categoryFromDb2);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order must be different");
            }
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Category.Add(obj);
                }
                else
                {
                    _unitOfWork.Category.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Category " + ((obj.Id != 0 ? "Updated" : "Created")) + " successfully";
                return RedirectToAction(Constants.ActionIndex, Constants.ControllerCategory);
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb2 = _unitOfWork.Category.Get(u => u.Id == Id);
            if (categoryFromDb2 == null)
            {
                return NotFound();
            }
            return View(categoryFromDb2);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Category? category = _unitOfWork.Category.Get(u => u.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction(Constants.ActionIndex, Constants.ControllerCategory);
        }
    }
}
