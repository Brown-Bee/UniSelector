using Microsoft.AspNetCore.Identity;
using UniSelector.DataAccess.Repository.IRepository;
using UniSelector.Models;

public interface IApplicationUserRepository
{
    Task<IEnumerable<ApplicationUser>> GetAllUsers();
    Task<ApplicationUser> GetUserById(string id);
    Task<IdentityResult> CreateUser(ApplicationUser user, string password);
    Task<IdentityResult> UpdateUser(ApplicationUser user);
    Task<IdentityResult> DeleteUser(ApplicationUser user);
    ApplicationUser GetByEmail(string email);
    
}