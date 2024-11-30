using Microsoft.AspNetCore.Identity;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    bool Update(ApplicationUser user);
}