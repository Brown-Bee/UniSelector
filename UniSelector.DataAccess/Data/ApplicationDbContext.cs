using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using UniSelector.Models;

namespace UniSelector.DataAccess.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<University> Universities { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<StandardFaculty> StandardFaculties { get; set; }
    public DbSet<StudentRequest> StudetsRequests { get; set; }
    public DbSet<Major> Majors { get; set; }
    public DbSet<StandardMajor> StandardMajors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<University>().HasData(
            new University
            {
                Id = 1,
                Name = "Arab Open University (AOU)",
                type = "Private",
                FullDescription = "A leading open education institution in the Arab world.",
                SmallDescription = "",
                location = "العارضية-Ardya",
                KuwaitRank = 1,
                Budget = 4500,
                PhoneNumber = "99999999",

                ImageUrl = "/images/University/AOU.png"
            },
            new University
            {   
                Id = 2,
                Name = "American University In Middle East (AUM)",
                type = "Private",
                FullDescription = "Offering American-style education with a Middle Eastern perspective.",
                SmallDescription = "",
                location = "العقيلة-Egila",
                KuwaitRank = 2,
                Budget = 25000,
                PhoneNumber = "99999999",

                ImageUrl = "/images/University/AUM.png"
            },
            new University
            {
                Id = 3,
                Name = "American University Of Kuwait (AUK)",
                type = "Private",
                FullDescription = "Providing a comprehensive American liberal arts education.",
                SmallDescription = "",
                location = "السالمية-Salmya",
                KuwaitRank = 3,
                Budget = 15000,
                PhoneNumber = "99999999",

                ImageUrl = "/images/University/AUK.png"
            },
            new University
            {
                Id = 4,
                Name = "Kuwait University (KU)",
                type = "Public",
                FullDescription = "The premier public institution of higher education in Kuwait.",
                SmallDescription = "",
                location = "الشويخ-Shwaikh",
                KuwaitRank = 4,
                Budget = 13000,
                PhoneNumber = "99999999",
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
