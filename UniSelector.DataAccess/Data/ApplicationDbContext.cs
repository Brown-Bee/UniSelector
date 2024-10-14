using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniSelector.Models;

namespace UniSelector.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<StandardFaculty> StandardFaculties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
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
            new University
            {
                Id = 1,
                Name = "Arab Open University (AOU)",
                type = "Private",
                Description = "A leading open education institution in the Arab world.",
                location = "العارضية-Ardya",
                KuwaitRank = 1,
                Budget = 4500,
                ImageUrl = "/images/University/AOU.png"
            },
            new University
            {
                Id = 2,
                Name = "American University In Middle East (AUM)",
                type = "Private",
                Description = "Offering American-style education with a Middle Eastern perspective.",
                location = "العقيلة-Egila",
                KuwaitRank = 2,
                Budget = 25000,
                ImageUrl = "/images/University/AUM.png"
            },
            new University
            {
                Id = 3,
                Name = "American University Of Kuwait (AUK)",
                type = "Private",
                Description = "Providing a comprehensive American liberal arts education.",
                location = "السالمية-Salmya",
                KuwaitRank = 3,
                Budget = 15000,
                ImageUrl = "/images/University/AUK.png"
            },
            new University
            {
                Id = 4,
                Name = "Kuwait University (KU)",
                type = "Public",
                Description = "The premier public institution of higher education in Kuwait.",
                location = "الشويخ-Shwaikh",
                KuwaitRank = 4,
                Budget = 13000,
                ImageUrl = "/images/university/KU.png"
            });
        modelBuilder.Entity<StandardFaculty>().HasData(
            new StandardFaculty { Id = 1, NameArabic = "كلية الهندسة", NameEnglish = "College of Engineering" },
            new StandardFaculty { Id = 2, NameArabic = "كلية الطب", NameEnglish = "College of Medicine" },
            new StandardFaculty { Id = 3, NameArabic = "كلية العلوم", NameEnglish = "College of Science" },
            new StandardFaculty { Id = 4, NameArabic = "كلية إدارة الأعمال", NameEnglish = "College of Business Administration" },
            new StandardFaculty { Id = 5, NameArabic = "كلية الآداب", NameEnglish = "College of Arts" },
            new StandardFaculty { Id = 6, NameArabic = "كلية التربية", NameEnglish = "College of Education" },
            new StandardFaculty { Id = 7, NameArabic = "كلية الشريعة والدراسات الإسلامية", NameEnglish = "College of Sharia and Islamic Studies" },
            new StandardFaculty { Id = 8, NameArabic = "كلية الحقوق", NameEnglish = "College of Law" },
            new StandardFaculty { Id = 9, NameArabic = "كلية العلوم الاجتماعية", NameEnglish = "College of Social Sciences" },
            new StandardFaculty { Id = 10, NameArabic = "كلية طب الأسنان", NameEnglish = "College of Dentistry" },
            new StandardFaculty { Id = 11, NameArabic = "كلية الصيدلة", NameEnglish = "College of Pharmacy" },
            new StandardFaculty { Id = 12, NameArabic = "كلية العلوم الطبية المساعدة", NameEnglish = "College of Allied Health Sciences" },
            new StandardFaculty { Id = 13, NameArabic = "كلية العمارة", NameEnglish = "College of Architecture" },
            new StandardFaculty { Id = 14, NameArabic = "كلية علوم وهندسة الحاسوب", NameEnglish = "College of Computing Sciences and Engineering" },
            new StandardFaculty { Id = 15, NameArabic = "كلية الصحة العامة", NameEnglish = "College of Public Health" },
            new StandardFaculty { Id = 16, NameArabic = "كلية العلوم الحياتية", NameEnglish = "College of Life Sciences" },
            new StandardFaculty { Id = 17, NameArabic = "كلية الدراسات العليا", NameEnglish = "College of Graduate Studies" },
            new StandardFaculty { Id = 18, NameArabic = "كلية التمريض", NameEnglish = "College of Nursing" },
            new StandardFaculty { Id = 19, NameArabic = "كلية الدراسات الإسلامية", NameEnglish = "College of Islamic Studies" },
            new StandardFaculty { Id = 20, NameArabic = "كلية الفنون والإعلام", NameEnglish = "College of Arts and Media" }
);


       
    }

}
