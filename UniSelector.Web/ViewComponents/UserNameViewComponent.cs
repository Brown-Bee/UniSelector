using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

namespace UniSelector.Web.ViewComponents;

public class UserNameViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;

    public UserNameViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync(string id)
    {
        var user = await _unitOfWork.ApplicationUser.GetUserById(id);
        return View("Default", user.Name);
    }
}