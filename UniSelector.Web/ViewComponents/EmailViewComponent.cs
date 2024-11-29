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
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            var user = await _unitOfWork.ApplicationUser.GetUserById(Id);
            return View("Default", user.Email);
        }
    }
}
