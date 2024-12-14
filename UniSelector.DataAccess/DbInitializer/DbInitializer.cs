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
            // Apply migration if they are not applied 
            try
            {
                Console.WriteLine("Starting database initialization...");

                // Check for pending migrations
                var pendingMigrations = await _db.Database.GetPendingMigrationsAsync();
                if (pendingMigrations.Any())
                {
                    Console.WriteLine($"Found {pendingMigrations.Count()} pending migrations. Applying...");
                    await _db.Database.MigrateAsync();
                    Console.WriteLine("Migrations applied successfully.");
                }
                else
                {
                    Console.WriteLine("No pending migrations found.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred during database initialization: {e.Message}");
                Console.WriteLine($"Stack trace: {e.StackTrace}");
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
    }
}