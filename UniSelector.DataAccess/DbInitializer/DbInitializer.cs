using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniSelector.DataAccess.Data;
using UniSelector.Models;
using UniSelector.Utility;

namespace UniSelector.DataAccess.DbInitializer
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        // Initialize database with admin account
        public async Task Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    await _db.Database.MigrateAsync();
                }

                if (!await _roleManager.RoleExistsAsync(SD.RoleAdmin))
                {
                    await _roleManager.CreateAsync(new IdentityRole(SD.RoleAdmin));
                    await _roleManager.CreateAsync(new IdentityRole(SD.RoleUser));
                    await _roleManager.CreateAsync(new IdentityRole(SD.RoleUniversity));

                    var admin = new ApplicationUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        Name = "Admin",
                        Gender = "Male",
                        Nationality = "Yemeni",
                        PhoneNumber = "55443322",
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(admin, "Admin#1234");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(admin, SD.RoleAdmin);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database initialization failed: {ex.Message}");
            }
        }
    }
}