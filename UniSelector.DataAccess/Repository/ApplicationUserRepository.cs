using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniSelector.Models;

public class ApplicationUserRepository : IApplicationUserRepository     
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<ApplicationUser> GetUserById(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
    {
        // Generate a new Id for the user
        /*user.Id = Guid.NewGuid().ToString();*/
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> UpdateUser(ApplicationUser user)
    {
        return await _userManager.UpdateAsync(user);
    }

    public async Task<IdentityResult> DeleteUser(ApplicationUser user)
    {
        return await _userManager.DeleteAsync(user);
    }

    public ApplicationUser GetByEmail(string email)
    {
        return _userManager.FindByEmailAsync(email).Result;
    }

    
}