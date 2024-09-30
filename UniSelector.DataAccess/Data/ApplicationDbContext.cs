using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniSelector.Models;

namespace UniSelector.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<GalleryImage> GalleryImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*modelBuilder.Entity<Faculty>().HasData(
            new Faculty { Id = 1, Name = "Engineering"},
            new Faculty {Id = 2, Name = "Medicine" },
            new Faculty {Id = 3, Name = "Information Technology" },
            new Faculty {Id = 4, Name = "Business Administration" },
            new Faculty {Id = 5, Name = "Accounting" },
            new Faculty {Id = 6, Name = "Marketing" },
            new Faculty {Id = 7, Name = "Law" },
            new Faculty {Id = 8, Name = "Science" },
            new Faculty {Id = 9, Name = "Arts and Humanities" },
            new Faculty {Id = 10, Name = "Education" },
            new Faculty {Id = 11, Name = "Pharmacy" },
            new Faculty {Id = 12, Name = "Dentistry" },
            new Faculty {Id = 13, Name = "Architecture" },
            new Faculty {Id = 14, Name = "Nursing" },
            new Faculty {Id = 15, Name = "Allied Health Sciences" },
            new Faculty {Id = 16, Name = "Psychology" },
            new Faculty {Id = 17, Name = "Economics" },
            new Faculty {Id = 18, Name = "Political Science" },
            new Faculty {Id = 19, Name = "Islamic Studies" },
            new Faculty {Id = 20, Name = "Computer Science" }
            );*/
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Fortune of Time",
                Author = "Billy Spark",
                Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                ISBN = "SWD9999001",
                ListPrice = 99,
                Price = 90,
                Price50 = 85,
                Price100 = 80,
                CategoryId = 2,
                ImageUrl = ""
            },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""

                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                }
            );
        modelBuilder.Entity<University>().HasData(
            new University {
                Id = 1,
                Name = "Arab Open Universities",
                type = "Private",
                Description = "Good university",
                location = "العارضية-Ardya",
                KuwaitRank = 1,
                Budget = 0,
                ImageUrl = ""
            },
            new University
            {
                Id = 2,
                Name = "American Universities In Middle East (AUM)",
                type = "Private",
                Description = "Good university",
                location = "العقيلة-Egila",
                KuwaitRank = 2,
                Budget = 0,
                ImageUrl = ""
            },
            new University
            {
                Id = 3,
                Name = "American Universities Of Kuwait",
                type = "Private",
                Description = "Good university",
                location = "السالمية-Salmya",
                KuwaitRank = 3,
                Budget = 0,
                ImageUrl = ""
            },
            new University
            {
                Id = 4,
                Name = "Kuwait Universities",
                type = "Public",
                Description = "Good university",
                location = "الشويخ-Shwaikh",
                KuwaitRank = 4,
                Budget = 0,
                ImageUrl = ""
            }
            );
    }

}
