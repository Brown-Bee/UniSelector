using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using UniSelector.DataAccess.Repository.IRepository;

namespace UniSelector.Web.ViewComponents
{
    public class EmailViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var user = _unitOfWork.ApplicationUser.Get(a => a.Id == id);
            return View(user.Email);
        }
    }
}
