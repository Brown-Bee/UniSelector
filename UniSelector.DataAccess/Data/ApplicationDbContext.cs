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
    public DbSet<Major> Majors { get; set; }
    public DbSet<StandardMajor> StandardMajors { get; set; }
    public DbSet<Application> Applications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<University>().HasData(
   new University
   {
       Id = 1,
       Name = "American University of Kuwait (AUK)",
       type = "Private",
       FullDescription = "Accredited liberal arts institution offering American-style education since 2004. Located in Salmiya, Kuwait's premier university district.",
       SmallDescription = "Kuwait's leading American-style liberal arts university",
       location = "Salmiya, Block 13, Salem Al Mubarak Street",
       KuwaitRank = 1,
       PhoneNumber = "1802040",
       ImageUrl = "/images/University/AUK.png"
   },
   new University
   {
       Id = 2,
       Name = "American University of Middle East (AUM)",
       type = "Private",
       FullDescription = "Leading engineering and business focused university established in 2008. Known for strong industry partnerships and state-of-the-art facilities.",
       SmallDescription = "Premier engineering and business education in Kuwait",
       location = "Egaila, Block 6, Salem Sabah Al-Salem Area",
       KuwaitRank = 2,
       PhoneNumber = "+965 22251400",
       ImageUrl = "/images/University/AUM.png"
   },
   new University
   {
       Id = 3,
       Name = "Gulf University for Science and Technology (GUST)",
       type = "Private",
       FullDescription = "First private university in Kuwait, established in 2002. Offers American-style education with focus on business and technology.",
       SmallDescription = "Kuwait's first private university for business and technology",
       location = "Mubarak Al-Abdullah Area, West Mishref",
       KuwaitRank = 3,
       PhoneNumber = "25307000",
       ImageUrl = "/images/University/GUST.png"
   },
   new University
   {
       Id = 4,
       Name = "Arab Open University (AOU)",
       type = "Private",
       FullDescription = "Regional university focused on accessible education since 2002. Partners with UK Open University for international accreditation.",
       SmallDescription = "Accessible quality education across Kuwait",
       location = "Al-Ardiya, Block 3, Street 37",
       KuwaitRank = 4,
       PhoneNumber = "24394400",
       ImageUrl = "/images/University/AOU.png"
   },
   new University
   {
       Id = 5,
       Name = "Kuwait College of Science and Technology (KCST)",
       type = "Private",
       FullDescription = "Specialized institution focusing on engineering and technology education. Strong emphasis on practical skills and industry readiness.",
       SmallDescription = "Advanced technical education in Kuwait",
       location = "Doha District, Block 4",
       KuwaitRank = 5,
       PhoneNumber = "24980450",
       ImageUrl = "/images/University/KCST.png"
   },
   new University
   {
       Id = 6,
       Name = "Australian University (AU)",
       type = "Private",
       FullDescription = "Australian-standard technical and vocational education. Strong focus on engineering and maritime studies.",
       SmallDescription = "Australian-standard technical education",
       location = "Mishref, Block 5",
       KuwaitRank = 6,
       PhoneNumber = "1828225",
       ImageUrl = "/images/University/AU.png"
   },
   new University
   {
       Id = 7,
       Name = "Box Hill College Kuwait",
       type = "Private",
       FullDescription = "Women's college offering Australian-standard education in business, design and technology.",
       SmallDescription = "Quality education for women in Kuwait",
       location = "Abu Halifa, Block 1",
       KuwaitRank = 7,
       PhoneNumber = "23962000",
       ImageUrl = "/images/University/BHCK.png"
   },
   new University
   {
       Id = 8,
       Name = "Kuwait International Law School",
       type = "Private",
       FullDescription = "Specialized institution focused on legal education and jurisprudence studies.",
       SmallDescription = "Premier legal education in Kuwait",
       location = "Doha, Block 2",
       KuwaitRank = 8,
       PhoneNumber = "22280111",
       ImageUrl = "/images/University/KILAW.png"
   },
   new University
   {
       Id = 9,
       Name = "College of Aviation Technology",
       type = "Private",
       FullDescription = "Specialized college offering aviation engineering and management programs.",
       SmallDescription = "Kuwait's aviation education hub",
       location = "Kuwait International Airport Area",
       KuwaitRank = 9,
       PhoneNumber = "24315555",
       ImageUrl = "/images/University/CAT.png"
   },
   new University
   {
       Id = 10,
       Name = "Kuwait Technical College",
       type = "Private",
       FullDescription = "Modern technical college focusing on IT, business and telecommunications.",
       SmallDescription = "Advanced technical education",
       location = "Shuwaikh Educational Area",
       KuwaitRank = 10,
       PhoneNumber = "22280222",
       ImageUrl = "/images/University/KTECH.png"
   },
   new University
   {
       Id = 11,
       Name = "Kuwait University",
       type = "Public",
       FullDescription = "Established in 1966, Kuwait's first public university offering comprehensive education across multiple campuses",
       SmallDescription = "Kuwait's premier public higher education institution",
       location = "Multiple campuses - Main in Khaldiya",
       KuwaitRank = 11,
       PhoneNumber = "24987000",
       ImageUrl = "/images/University/KU.png"
   }
);

        modelBuilder.Entity<Faculty>().HasData(
    // AUK Faculties
    new Faculty
    {
        Id = 1,
        StandardFacultyId = 5, // College of Arts & Sciences
        UniversityId = 1,
        Description = "Comprehensive liberal arts education with diverse programs in humanities and sciences",
        AdmissionRequirements = "Minimum 70% high school GPA, TOEFL 80+ or IELTS 6.5+"
    },
    new Faculty
    {
        Id = 2,
        StandardFacultyId = 4, // Business & Economics
        UniversityId = 1,
        Description = "AACSB-accredited business programs with focus on global business practices",
        AdmissionRequirements = "Minimum 70% high school GPA, TOEFL 80+ or IELTS 6.5+"
    },
    new Faculty
    {
        Id = 3,
        StandardFacultyId = 1, // Engineering
        UniversityId = 1,
        Description = "ABET-accredited engineering programs with state-of-the-art facilities",
        AdmissionRequirements = "Minimum 75% high school GPA in Scientific track, Strong math/science background"
    },
    new Faculty
    {
        Id = 4,
        StandardFacultyId = 13, // Architecture & Design
        UniversityId = 1,
        Description = "Creative design education with focus on practical applications",
        AdmissionRequirements = "Minimum 70% high school GPA, Portfolio submission required"
    },

    // AUM Faculties
    new Faculty
    {
        Id = 5,
        StandardFacultyId = 14, // Engineering & Technology
        UniversityId = 2,
        Description = "Comprehensive engineering programs with modern laboratories",
        AdmissionRequirements = "Minimum 75% in Scientific track, Strong mathematics background"
    },
    new Faculty
    {
        Id = 6,
        StandardFacultyId = 4, // Business Administration
        UniversityId = 2,
        Description = "Industry-focused business education with international accreditation",
        AdmissionRequirements = "Minimum 70% high school GPA, English proficiency required"
    },
   // GUST Faculties
   new Faculty
   {
       Id = 7,
       StandardFacultyId = 5, // Arts & Sciences
       UniversityId = 3,
       Description = "Comprehensive programs in humanities, media, and computer science",
       AdmissionRequirements = "Minimum 70% GPA, TOEFL 79+ or IELTS 6.5+"
   },
   new Faculty
   {
       Id = 8,
       StandardFacultyId = 4, // Business Administration
       UniversityId = 3,
       Description = "AACSB-accredited business school with focus on practical skills",
       AdmissionRequirements = "Minimum 70% GPA, English proficiency required"
   },

   // KCST Faculties
   new Faculty
   {
       Id = 9,
       StandardFacultyId = 14, // Engineering & Computer Science
       UniversityId = 5,
       Description = "Advanced technical education in engineering and computing",
       AdmissionRequirements = "Minimum 75% in Scientific stream, Strong math background"
   },

   // AOU Faculties
   new Faculty
   {
       Id = 10,
       StandardFacultyId = 4, // Business Administration
       UniversityId = 4,
       Description = "Flexible business education with UK partnership",
       AdmissionRequirements = "Minimum 60% GPA, Basic English proficiency"
   },
   new Faculty
   {
       Id = 11,
       StandardFacultyId = 14, // Computing Sciences
       UniversityId = 4,
       Description = "IT and computing programs with international recognition",
       AdmissionRequirements = "Minimum 65% GPA, Basic programming knowledge preferred"
   },
   new Faculty
   {
       Id = 20,
       StandardFacultyId = 5, // Arts & Sciences
       UniversityId = 4, // AOU
       Description = "English language and literature studies with focus on linguistics and translation",
       AdmissionRequirements = "Minimum 60% GPA, Higher English proficiency required"
   },

   // ACK Faculties 
   new Faculty
   {
       Id = 12,
       StandardFacultyId = 1, // Engineering
       UniversityId = 6,
       Description = "Australian-standard engineering education",
       AdmissionRequirements = "Minimum 75% in Scientific track, Mathematics proficiency"
   },
   new Faculty
   {
       Id = 13,
       StandardFacultyId = 4, // Business
       UniversityId = 6,
       Description = "Business programs with Australian curriculum",
       AdmissionRequirements = "Minimum 70% GPA, English proficiency required"
   },

   // Box Hill Faculties
   new Faculty
   {
       Id = 14,
       StandardFacultyId = 4, // Business
       UniversityId = 7,
       Description = "Women's business education with Australian standards",
       AdmissionRequirements = "Minimum 65% GPA, English proficiency test"
   },
   new Faculty
   {
       Id = 15,
       StandardFacultyId = 20, // Arts & Design
       UniversityId = 7,
       Description = "Creative arts and design programs for women",
       AdmissionRequirements = "Portfolio submission, Interview required"
   },
   // Kuwait Law School
   new Faculty
   {
       Id = 16,
       StandardFacultyId = 8, // Law
       UniversityId = 8,
       Description = "Comprehensive legal education with focus on Kuwait and international law",
       AdmissionRequirements = "Minimum 75% GPA, Arabic and English proficiency"
   },

   // Aviation College
   new Faculty
   {
       Id = 17,
       StandardFacultyId = 1, // Engineering (Aviation)
       UniversityId = 9,
       Description = "Specialized aviation engineering and maintenance programs",
       AdmissionRequirements = "Minimum 75% in Scientific track, English proficiency required"
   },

   // Kuwait Technical College
   new Faculty
   {
       Id = 18,
       StandardFacultyId = 14, // Computing Sciences
       UniversityId = 10,
       Description = "Technical IT and networking education",
       AdmissionRequirements = "Minimum 65% GPA, Basic technical aptitude"
   },
   new Faculty
   {
       Id = 19,
       StandardFacultyId = 4, // Business
       UniversityId = 10,
       Description = "Applied business and management programs",
       AdmissionRequirements = "Minimum 65% GPA, English proficiency test"
   },
    // KU Faculties
    new Faculty
    {
        Id = 21,
        StandardFacultyId = 1, // Engineering
        UniversityId = 11,
        Description = "Leading engineering programs with ABET accreditation",
        AdmissionRequirements = "Minimum 80% in Scientific track, Aptitude test required"
    },
    new Faculty
    {
        Id = 22,
        StandardFacultyId = 3, // Science
        UniversityId = 11,
        Description = "Research-focused science programs across multiple disciplines",
        AdmissionRequirements = "Minimum 75% in Scientific track, Aptitude test required"
    },
    new Faculty
    {
        Id = 23,
        StandardFacultyId = 2, // Medicine
        UniversityId = 11,
        Description = "Premier medical education in Kuwait",
        AdmissionRequirements = "Minimum 90% in Scientific track, Aptitude test required"
    },
    new Faculty
    {
        Id = 24,
        StandardFacultyId = 12, // Allied Health Sciences
        UniversityId = 11,
        Description = "Healthcare professional programs with clinical training",
        AdmissionRequirements = "Minimum 75% in Scientific track, Aptitude test required"
    },
    new Faculty
    {
        Id = 25,
        StandardFacultyId = 11, // Pharmacy
        UniversityId = 11,
        Description = "PharmD program with extensive clinical training",
        AdmissionRequirements = "Minimum 85% in Scientific track, Aptitude test required"
    },
    new Faculty
    {
        Id = 26,
        StandardFacultyId = 10, // Dentistry
        UniversityId = 11,
        Description = "Advanced dental education with modern facilities",
        AdmissionRequirements = "Minimum 85% in Scientific track, Aptitude test required"
    },
    new Faculty
    {
        Id = 27,
        StandardFacultyId = 4, // Business Administration
        UniversityId = 11,
        Description = "AACSB-accredited business programs",
        AdmissionRequirements = "Minimum 75% in Either track, Aptitude test required"
    },
    new Faculty
    {
        Id = 28,
        StandardFacultyId = 5, // Arts
        UniversityId = 11,
        Description = "Comprehensive humanities and social sciences programs",
        AdmissionRequirements = "Minimum 70% in Either track, Aptitude test required"
    },
    new Faculty
    {
        Id = 29,
        StandardFacultyId = 8, // Law
        UniversityId = 11,
        Description = "Kuwait's premier legal education program",
        AdmissionRequirements = "Minimum 80% in Either track, Aptitude test required"
    },
    new Faculty
    {
        Id = 30,
        StandardFacultyId = 6, // Education
        UniversityId = 11,
        Description = "Teacher preparation and educational research programs",
        AdmissionRequirements = "Minimum 70% in Either track, Aptitude test required"
    },
    new Faculty
    {
        Id = 31,
        StandardFacultyId = 7, // Sharia
        UniversityId = 11,
        Description = "Islamic studies and jurisprudence programs",
        AdmissionRequirements = "Minimum 70% in Either track, Aptitude test required"
    }
   );



        modelBuilder.Entity<Major>().HasData(
    // AUK Arts & Sciences Majors (Faculty 1)
    new Major
    {
        Id = 1,
        StandardMajorId = 17, // English
        FacultyId = 1,
        Credits = 124,
        AveragePrice = 16000,
        MinimumGrade = 70,
        MinimumIELTS = 6.5,
        MinimumTOEFL = 80,
        RequiresAptitudeTest = false,
        AverageStartingSalary = 800
    },
    new Major
    {
        Id = 2,
        StandardMajorId = 77, // Communication & Media
        FacultyId = 1,
        Credits = 124,
        AveragePrice = 16000,
        MinimumGrade = 70,
        MinimumIELTS = 6.5,
        MinimumTOEFL = 80,
        RequiresAptitudeTest = false,
        AverageStartingSalary = 850
    },
    new Major
    {
        Id = 3,
        StandardMajorId = 53, // Computer Science
        FacultyId = 1,
        Credits = 130,
        AveragePrice = 17000,
        MinimumGrade = 75,
        MinimumIELTS = 6.5,
        MinimumTOEFL = 80,
        RequiresAptitudeTest = true,
        AverageStartingSalary = 1200
    },

   // AUK Business Majors (Faculty 2)
   new Major
   {
       Id = 4,
       StandardMajorId = 13, // Accounting
       FacultyId = 2,
       Credits = 128,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 1000
   },
   new Major
   {
       Id = 5,
       StandardMajorId = 16, // Finance
       FacultyId = 2,
       Credits = 128,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 1100
   },
   new Major
   {
       Id = 6,
       StandardMajorId = 15, // Management
       FacultyId = 2,
       Credits = 128,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 950
   },
   new Major
   {
       Id = 7,
       StandardMajorId = 14, // Marketing
       FacultyId = 2,
       Credits = 128,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 900
   },

   // AUK Engineering Majors (Faculty 3)
   new Major
   {
       Id = 8,
       StandardMajorId = 1, // Electrical Engineering
       FacultyId = 3,
       Credits = 140,
       AveragePrice = 18000,
       MinimumGrade = 75,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1300
   },

   new Major
   {
       Id = 9,
       StandardMajorId = 54, // Computer Engineering
       FacultyId = 3,
       Credits = 140,
       AveragePrice = 18000,
       MinimumGrade = 75,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1350
   },
   new Major
   {
       Id = 10,
       StandardMajorId = 55, // Systems Engineering
       FacultyId = 3,
       Credits = 140,
       AveragePrice = 18000,
       MinimumGrade = 75,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1250
   },
   // AUK Architecture & Design (Faculty 4)
   new Major
   {
       Id = 21,
       StandardMajorId = 50, // Interior Design
       FacultyId = 4,
       Credits = 132,
       AveragePrice = 17500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 900
   },
   new Major
   {
       Id = 22,
       StandardMajorId = 79, // Graphic Design
       FacultyId = 4,
       Credits = 132,
       AveragePrice = 17500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 850
   },
   // AUM Engineering & Technology Majors (Faculty 5)
   new Major
   {
       Id = 11,
       StandardMajorId = 2, // Civil Engineering
       FacultyId = 5,
       Credits = 140,
       AveragePrice = 19000,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1200
   },
   new Major
   {
       Id = 12,
       StandardMajorId = 54, // Computer Engineering
       FacultyId = 5,
       Credits = 140,
       AveragePrice = 19000,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1300
   },
   new Major
   {
       Id = 13,
       StandardMajorId = 1, // Electrical Engineering
       FacultyId = 5,
       Credits = 140,
       AveragePrice = 19000,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1250
   },
   new Major
   {
       Id = 14,
       StandardMajorId = 3, // Mechanical Engineering
       FacultyId = 5,
       Credits = 140,
       AveragePrice = 19000,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1200
   },
   new Major
   {
       Id = 15,
       StandardMajorId = 4, // Chemical Engineering
       FacultyId = 5,
       Credits = 140,
       AveragePrice = 19000,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1150
   },
   // AUM Business Majors (Faculty 6)
   new Major
   {
       Id = 16,
       StandardMajorId = 13, // Accounting
       FacultyId = 6,
       Credits = 130,
       AveragePrice = 17000,
       MinimumGrade = 70,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 900
   },
   new Major
   {
       Id = 17,
       StandardMajorId = 16, // Finance
       FacultyId = 6,
       Credits = 130,
       AveragePrice = 17000,
       MinimumGrade = 70,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 950
   },
   new Major
   {
       Id = 18,
       StandardMajorId = 14, // Marketing
       FacultyId = 6,
       Credits = 130,
       AveragePrice = 17000,
       MinimumGrade = 70,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 850
   },
   new Major
   {
       Id = 19,
       StandardMajorId = 55, // Management Information Systems
       FacultyId = 6,
       Credits = 130,
       AveragePrice = 17000,
       MinimumGrade = 70,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 900
   },
   // GUST Arts & Sciences Majors (Faculty 7)
   new Major
   {
       Id = 20,
       StandardMajorId = 77, // Media Studies
       FacultyId = 7,
       Credits = 132,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 79,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 800
   },
   new Major
   {
       Id = 23,
       StandardMajorId = 53, // Computer Science
       FacultyId = 7,
       Credits = 130,
       AveragePrice = 16500,
       MinimumGrade = 75,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 79,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1100
   },
   // GUST Business Majors (Faculty 8)
   new Major
   {
       Id = 24,
       StandardMajorId = 13, // Accounting
       FacultyId = 8,
       Credits = 130,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 79,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 950
   },
   new Major
   {
       Id = 25,
       StandardMajorId = 16, // Finance
       FacultyId = 8,
       Credits = 130,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 79,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 1000
   },
   new Major
   {
       Id = 26,
       StandardMajorId = 15, // Management
       FacultyId = 8,
       Credits = 130,
       AveragePrice = 16500,
       MinimumGrade = 70,
       MinimumIELTS = 6.5,
       MinimumTOEFL = 79,
       RequiresAptitudeTest = false,
       AverageStartingSalary = 900
   },
   // KCST Engineering & CS Majors (Faculty 9)
   new Major
   {
       Id = 27,
       StandardMajorId = 54, // Computer Engineering
       FacultyId = 9,
       Credits = 135,
       AveragePrice = 15500,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1100
   },
   new Major
   {
       Id = 28,
       StandardMajorId = 84, // Electronics & Communications Engineering
       FacultyId = 9,
       Credits = 135,
       AveragePrice = 15500,
       MinimumGrade = 75,
       MinimumIELTS = 6.0,
       MinimumTOEFL = 80,
       RequiresAptitudeTest = true,
       AverageStartingSalary = 1000
   },
    new Major
    {
        Id = 29,
        StandardMajorId = 55, // Information Technology
        FacultyId = 9,
        Credits = 130,
        AveragePrice = 15000,
        MinimumGrade = 70,
        MinimumIELTS = 6.0,
        MinimumTOEFL = 80,
        RequiresAptitudeTest = false,
        AverageStartingSalary = 950
    },
// AOU Business Administration (Faculty 10)
new Major
{
    Id = 30,
    StandardMajorId = 15, // Management
    FacultyId = 10,
    Credits = 132,
    AveragePrice = 12000,
    MinimumGrade = 60,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 750
},
new Major
{
    Id = 31,
    StandardMajorId = 14, // Marketing
    FacultyId = 10,
    Credits = 132,
    AveragePrice = 12000,
    MinimumGrade = 60,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 750
},
new Major
{
    Id = 32,
    StandardMajorId = 13, // Accounting
    FacultyId = 10,
    Credits = 132,
    AveragePrice = 12000,
    MinimumGrade = 60,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 800
},
new Major
{
    Id = 33,
    StandardMajorId = 55, // Management Information Systems
    FacultyId = 10,
    Credits = 132,
    AveragePrice = 12000,
    MinimumGrade = 60,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 800
},
// AOU IT Faculty (Faculty 11)
new Major
{
    Id = 34,
    StandardMajorId = 55, // Information Technology
    FacultyId = 11,
    Credits = 135,
    AveragePrice = 12500,
    MinimumGrade = 65,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 850
},

// AOU English Language (Need to add Faculty first)
new Major
{
    Id = 35,
    StandardMajorId = 17, // English Language & Literature
    FacultyId = 20, // New Faculty ID needed
    Credits = 132,
    AveragePrice = 12000,
    MinimumGrade = 60,
    MinimumIELTS = 6.0,
    MinimumTOEFL = 78,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 700
},
// ACK Majors (Faculty 12 & 13)
new Major
{
    Id = 36,
    StandardMajorId = 1, // Electrical Engineering
    FacultyId = 12,
    Credits = 140,
    AveragePrice = 16000,
    MinimumGrade = 70,
    MinimumIELTS = 6.0,
    MinimumTOEFL = 78,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1000
},
new Major
{
    Id = 37,
    StandardMajorId = 15, // Business Administration
    FacultyId = 13,
    Credits = 132,
    AveragePrice = 15000,
    MinimumGrade = 65,
    MinimumIELTS = 6.0,
    MinimumTOEFL = 78,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 850
},
// Box Hill Majors (Faculty 14 & 15)
new Major
{
    Id = 38,
    StandardMajorId = 15, // Business
    FacultyId = 14,
    Credits = 130,
    AveragePrice = 14000,
    MinimumGrade = 65,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 800
},
new Major
{
    Id = 39,
    StandardMajorId = 79, // Art & Design
    FacultyId = 15,
    Credits = 130,
    AveragePrice = 14000,
    MinimumGrade = 65,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 750
},
new Major
{
    Id = 40,
    StandardMajorId = 55, // Information Technology
    FacultyId = 15,
    Credits = 132,
    AveragePrice = 14500,
    MinimumGrade = 65,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 900
},
// Kuwait Law School (Faculty 16)
new Major
{
    Id = 41,
    StandardMajorId = 29, // Law
    FacultyId = 16,
    Credits = 140,
    AveragePrice = 16000,
    MinimumGrade = 75,
    MinimumIELTS = 6.0,
    MinimumTOEFL = 78,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 1000
},
// Aviation College (Faculty 17)
new Major
{
    Id = 42,
    StandardMajorId = 82, // Aviation Engineering
    FacultyId = 17,
    Credits = 140,
    AveragePrice = 18000,
    MinimumGrade = 75,
    MinimumIELTS = 6.0,
    MinimumTOEFL = 80,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1200
},
new Major
{
    Id = 43,
    StandardMajorId = 83, // Aviation Management
    FacultyId = 17,
    Credits = 135,
    AveragePrice = 17000,
    MinimumGrade = 70,
    MinimumIELTS = 6.0,
    MinimumTOEFL = 80,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 1000
},

// Kuwait Technical College (Faculty 18 & 19)
new Major
{
    Id = 44,
    StandardMajorId = 55, // Information Technology
    FacultyId = 18,
    Credits = 130,
    AveragePrice = 13000,
    MinimumGrade = 65,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 850
},
new Major
{
    Id = 45,
    StandardMajorId = 15, // Business Administration
    FacultyId = 19,
    Credits = 130,
    AveragePrice = 13000,
    MinimumGrade = 65,
    MinimumIELTS = 5.5,
    MinimumTOEFL = 75,
    RequiresAptitudeTest = false,
    AverageStartingSalary = 800
},
// KU Engineering Majors
new Major
{
    Id = 46,
    StandardMajorId = 4, // Chemical Engineering
    FacultyId = 21,
    Credits = 144,
    AveragePrice = 0, // Public university
    MinimumGrade = 80,
    MinimumIELTS = null, // Not required for public
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1200
},
new Major
{
    Id = 47,
    StandardMajorId = 2, // Civil Engineering
    FacultyId = 21,
    Credits = 144,
    AveragePrice = 0,
    MinimumGrade = 80,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1200
},
new Major
{
    Id = 48,
    StandardMajorId = 54, // Computer Engineering
    FacultyId = 21,
    Credits = 144,
    AveragePrice = 0,
    MinimumGrade = 80,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1300
},
new Major
{
    Id = 49,
    StandardMajorId = 1, // Electrical Engineering
    FacultyId = 21,
    Credits = 144,
    AveragePrice = 0,
    MinimumGrade = 80,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1250
},
new Major
{
    Id = 50,
    StandardMajorId = 3, // Mechanical Engineering
    FacultyId = 21,
    Credits = 144,
    AveragePrice = 0,
    MinimumGrade = 80,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1200
},
// KU Science Majors
new Major
{
    Id = 51,
    StandardMajorId = 12, // Mathematics
    FacultyId = 22,
    Credits = 132,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 900
},
new Major
{
    Id = 52,
    StandardMajorId = 9, // Physics
    FacultyId = 22,
    Credits = 132,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 850
},
new Major
{
    Id = 53,
    StandardMajorId = 10, // Chemistry
    FacultyId = 22,
    Credits = 132,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 900
},
new Major
{
    Id = 54,
    StandardMajorId = 11, // Biology
    FacultyId = 22,
    Credits = 132,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 850
},

// KU Medicine
new Major
{
    Id = 55,
    StandardMajorId = 5, // Medicine
    FacultyId = 23,
    Credits = 220,
    AveragePrice = 0,
    MinimumGrade = 90,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 2000
},
// KU Allied Health Majors
new Major
{
    Id = 56,
    StandardMajorId = 45, // Physical Therapy
    FacultyId = 24,
    Credits = 140,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1100
},
new Major
{
    Id = 57,
    StandardMajorId = 46, // Medical Laboratory
    FacultyId = 24,
    Credits = 135,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1000
},
// KU Pharmacy & Dentistry
new Major
{
    Id = 58,
    StandardMajorId = 41, // Pharmacy
    FacultyId = 25,
    Credits = 170,
    AveragePrice = 0,
    MinimumGrade = 85,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1500
},
new Major
{
    Id = 59,
    StandardMajorId = 37, // Dentistry
    FacultyId = 26,
    Credits = 180,
    AveragePrice = 0,
    MinimumGrade = 85,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1800
},
// KU Business Majors
new Major
{
    Id = 60,
    StandardMajorId = 13, // Accounting
    FacultyId = 27,
    Credits = 130,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1100
},
new Major
{
    Id = 61,
    StandardMajorId = 16, // Finance
    FacultyId = 27,
    Credits = 130,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1200
},
new Major
{
    Id = 62,
    StandardMajorId = 15, // Management
    FacultyId = 27,
    Credits = 130,
    AveragePrice = 0,
    MinimumGrade = 75,
    MinimumIELTS = null,
    MinimumTOEFL = null,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1000
},
// KU Business continued
new Major
{
    Id = 63,
    StandardMajorId = 14, // Marketing
    FacultyId = 27,
    Credits = 130,
    MinimumGrade = 75,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1000
},
new Major
{
    Id = 64,
    StandardMajorId = 55, // MIS
    FacultyId = 27,
    Credits = 130,
    MinimumGrade = 75,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1100
},

// KU Arts
new Major
{
    Id = 65,
    StandardMajorId = 18, // Arabic Language
    FacultyId = 28,
    Credits = 128,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 800
},
new Major
{
    Id = 66,
    StandardMajorId = 17, // English Language
    FacultyId = 28,
    Credits = 128,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 850
},
new Major
{
    Id = 67,
    StandardMajorId = 77, // Mass Communication
    FacultyId = 28,
    Credits = 128,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 900
},
// KU Law
new Major
{
    Id = 68,
    StandardMajorId = 29, // Law
    FacultyId = 29,
    Credits = 138,
    MinimumGrade = 80,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 1200
},
// KU Education
new Major
{
    Id = 69,
    StandardMajorId = 21, // Educational Technology
    FacultyId = 30,
    Credits = 132,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 900
},
new Major
{
    Id = 70,
    StandardMajorId = 66, // Educational Leadership
    FacultyId = 30,
    Credits = 132,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 950
},

// KU Sharia
new Major
{
    Id = 71,
    StandardMajorId = 25, // Islamic Jurisprudence
    FacultyId = 31,
    Credits = 132,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 850
},
new Major
{
    Id = 72,
    StandardMajorId = 26, // Islamic Theology
    FacultyId = 31,
    Credits = 132,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 800
},
new Major
{
    Id = 73,
    StandardMajorId = 27, // Quranic Studies
    FacultyId = 31,
    Credits = 132,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 800
},
new Major
{
    Id = 74,
    StandardMajorId = 28, // Hadith Studies
    FacultyId = 31,
    Credits = 132,
    MinimumGrade = 70,
    RequiresAptitudeTest = true,
    AverageStartingSalary = 800
}
);




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

        modelBuilder.Entity<StandardMajor>().HasData(
    // Engineering (1)
    new StandardMajor { Id = 1, StandardFacultyId = 1, NameArabic = "الهندسة الكهربائية", NameEnglish = "Electrical Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Focuses on electrical systems, power generation, and electronics" },
    new StandardMajor { Id = 2, StandardFacultyId = 1, NameArabic = "الهندسة المدنية", NameEnglish = "Civil Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Deals with design and construction of infrastructure" },
    new StandardMajor { Id = 3, StandardFacultyId = 1, NameArabic = "الهندسة الميكانيكية", NameEnglish = "Mechanical Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Studies mechanics, robotics, and thermal systems" },
    new StandardMajor { Id = 4, StandardFacultyId = 1, NameArabic = "الهندسة الكيميائية", NameEnglish = "Chemical Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Focuses on chemical processes and materials" },
    new StandardMajor { Id = 81, StandardFacultyId = 1, NameArabic = "الهندسة البحرية", NameEnglish = "Maritime Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Maritime engineering and naval architecture" },
    new StandardMajor { Id = 82, StandardFacultyId = 1, NameArabic = "هندسة الطيران", NameEnglish = "Aviation Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Aircraft engineering and maintenance" },
    new StandardMajor { Id = 84, StandardFacultyId = 1, NameArabic = "هندسة الإلكترونيات والاتصالات", NameEnglish = "Electronics & Communications Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Electronics and telecommunications systems" },

    // Medicine (2)
    new StandardMajor { Id = 5, StandardFacultyId = 2, NameArabic = "الطب العام", NameEnglish = "General Medicine", StudyDuration = 7, HighSchoolPath = "Scientific", Description = "Complete medical education program" },
    new StandardMajor { Id = 6, StandardFacultyId = 2, NameArabic = "طب الأطفال", NameEnglish = "Pediatrics", StudyDuration = 7, HighSchoolPath = "Scientific", Description = "Specializes in child healthcare" },
    new StandardMajor { Id = 7, StandardFacultyId = 2, NameArabic = "الجراحة", NameEnglish = "Surgery", StudyDuration = 7, HighSchoolPath = "Scientific", Description = "Focus on surgical procedures and care" },
    new StandardMajor { Id = 8, StandardFacultyId = 2, NameArabic = "طب الطوارئ", NameEnglish = "Emergency Medicine", StudyDuration = 7, HighSchoolPath = "Scientific", Description = "Emergency medical care and treatment" },

    // Science (3)
    new StandardMajor { Id = 9, StandardFacultyId = 3, NameArabic = "الفيزياء", NameEnglish = "Physics", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Study of matter and energy" },
    new StandardMajor { Id = 10, StandardFacultyId = 3, NameArabic = "الكيمياء", NameEnglish = "Chemistry", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Study of chemical compounds and reactions" },
    new StandardMajor { Id = 11, StandardFacultyId = 3, NameArabic = "الأحياء", NameEnglish = "Biology", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Study of living organisms" },
    new StandardMajor { Id = 12, StandardFacultyId = 3, NameArabic = "الرياضيات", NameEnglish = "Mathematics", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Advanced mathematical studies" },

    // Business Administration (4)
    new StandardMajor { Id = 13, StandardFacultyId = 4, NameArabic = "المحاسبة", NameEnglish = "Accounting", StudyDuration = 4, HighSchoolPath = "Both", Description = "Financial accounting and auditing" },
    new StandardMajor { Id = 14, StandardFacultyId = 4, NameArabic = "التسويق", NameEnglish = "Marketing", StudyDuration = 4, HighSchoolPath = "Both", Description = "Marketing strategies and consumer behavior" },
    new StandardMajor { Id = 15, StandardFacultyId = 4, NameArabic = "إدارة الأعمال", NameEnglish = "Business Management", StudyDuration = 4, HighSchoolPath = "Both", Description = "Business operations and strategy" },
    new StandardMajor { Id = 16, StandardFacultyId = 4, NameArabic = "التمويل", NameEnglish = "Finance", StudyDuration = 4, HighSchoolPath = "Both", Description = "Financial management and investment" },
    new StandardMajor { Id = 83, StandardFacultyId = 4, NameArabic = "إدارة الطيران", NameEnglish = "Aviation Management", StudyDuration = 4, HighSchoolPath = "Both", Description = "Aviation operations and management" },
    new StandardMajor { Id = 85, StandardFacultyId = 4, NameArabic = "إدارة الموارد البشرية", NameEnglish = "Human Resources Management", StudyDuration = 4, HighSchoolPath = "Both", Description = "Human resource management and development" },

    // Arts (5)
    new StandardMajor { Id = 17, StandardFacultyId = 5, NameArabic = "اللغة الإنجليزية", NameEnglish = "English Language", StudyDuration = 4, HighSchoolPath = "Both", Description = "English linguistics and literature" },
    new StandardMajor { Id = 18, StandardFacultyId = 5, NameArabic = "اللغة العربية", NameEnglish = "Arabic Language", StudyDuration = 4, HighSchoolPath = "Both", Description = "Arabic linguistics and literature" },
    new StandardMajor { Id = 19, StandardFacultyId = 5, NameArabic = "التاريخ", NameEnglish = "History", StudyDuration = 4, HighSchoolPath = "Literary", Description = "Historical studies and research" },
    new StandardMajor { Id = 20, StandardFacultyId = 5, NameArabic = "الفلسفة", NameEnglish = "Philosophy", StudyDuration = 4, HighSchoolPath = "Literary", Description = "Philosophical studies and ethics" },

    // Education (6)
    new StandardMajor { Id = 21, StandardFacultyId = 6, NameArabic = "التربية الابتدائية", NameEnglish = "Elementary Education", StudyDuration = 4, HighSchoolPath = "Both", Description = "Primary school teaching" },
    new StandardMajor { Id = 22, StandardFacultyId = 6, NameArabic = "التربية الخاصة", NameEnglish = "Special Education", StudyDuration = 4, HighSchoolPath = "Both", Description = "Special needs education" },
    new StandardMajor { Id = 23, StandardFacultyId = 6, NameArabic = "تعليم اللغة الإنجليزية", NameEnglish = "English Education", StudyDuration = 4, HighSchoolPath = "Both", Description = "English language teaching" },
    new StandardMajor { Id = 24, StandardFacultyId = 6, NameArabic = "تعليم الرياضيات", NameEnglish = "Mathematics Education", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Mathematics teaching" },

    // Sharia and Islamic Studies (7)
    new StandardMajor { Id = 25, StandardFacultyId = 7, NameArabic = "الفقه الإسلامي", NameEnglish = "Islamic Jurisprudence", StudyDuration = 4, HighSchoolPath = "Both", Description = "Islamic law and jurisprudence" },
    new StandardMajor { Id = 26, StandardFacultyId = 7, NameArabic = "أصول الدين", NameEnglish = "Islamic Theology", StudyDuration = 4, HighSchoolPath = "Both", Description = "Islamic theology and doctrine" },
    new StandardMajor { Id = 27, StandardFacultyId = 7, NameArabic = "الدراسات القرآنية", NameEnglish = "Quranic Studies", StudyDuration = 4, HighSchoolPath = "Both", Description = "Quran interpretation and sciences" },
    new StandardMajor { Id = 28, StandardFacultyId = 7, NameArabic = "الحديث وعلومه", NameEnglish = "Hadith Studies", StudyDuration = 4, HighSchoolPath = "Both", Description = "Study of prophetic traditions" },

    // Law (8)
    new StandardMajor { Id = 29, StandardFacultyId = 8, NameArabic = "القانون العام", NameEnglish = "Public Law", StudyDuration = 4, HighSchoolPath = "Both", Description = "Constitutional and administrative law" },
    new StandardMajor { Id = 30, StandardFacultyId = 8, NameArabic = "القانون الخاص", NameEnglish = "Private Law", StudyDuration = 4, HighSchoolPath = "Both", Description = "Civil and commercial law" },
    new StandardMajor { Id = 31, StandardFacultyId = 8, NameArabic = "القانون الجنائي", NameEnglish = "Criminal Law", StudyDuration = 4, HighSchoolPath = "Both", Description = "Criminal law and procedure" },
    new StandardMajor { Id = 32, StandardFacultyId = 8, NameArabic = "القانون الدولي", NameEnglish = "International Law", StudyDuration = 4, HighSchoolPath = "Both", Description = "International legal systems" },

    // Social Sciences (9)
    new StandardMajor { Id = 33, StandardFacultyId = 9, NameArabic = "علم النفس", NameEnglish = "Psychology", StudyDuration = 4, HighSchoolPath = "Both", Description = "Human behavior and mental processes" },
    new StandardMajor { Id = 34, StandardFacultyId = 9, NameArabic = "علم الاجتماع", NameEnglish = "Sociology", StudyDuration = 4, HighSchoolPath = "Both", Description = "Study of human society" },
    new StandardMajor { Id = 35, StandardFacultyId = 9, NameArabic = "الخدمة الاجتماعية", NameEnglish = "Social Work", StudyDuration = 4, HighSchoolPath = "Both", Description = "Community service and welfare" },
    new StandardMajor { Id = 36, StandardFacultyId = 9, NameArabic = "العلوم السياسية", NameEnglish = "Political Science", StudyDuration = 4, HighSchoolPath = "Both", Description = "Political systems and relations" },

    // Dentistry (10)
    new StandardMajor { Id = 37, StandardFacultyId = 10, NameArabic = "طب الأسنان العام", NameEnglish = "General Dentistry", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Comprehensive dental care" },
    new StandardMajor { Id = 38, StandardFacultyId = 10, NameArabic = "جراحة الفم والأسنان", NameEnglish = "Oral Surgery", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Dental surgical procedures" },
    new StandardMajor { Id = 39, StandardFacultyId = 10, NameArabic = "تقويم الأسنان", NameEnglish = "Orthodontics", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Dental alignment and correction" },
    new StandardMajor { Id = 40, StandardFacultyId = 10, NameArabic = "طب أسنان الأطفال", NameEnglish = "Pediatric Dentistry", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Children's dental care" },

    // Pharmacy (11)
    new StandardMajor { Id = 41, StandardFacultyId = 11, NameArabic = "الصيدلة العامة", NameEnglish = "General Pharmacy", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Pharmaceutical sciences" },
    new StandardMajor { Id = 42, StandardFacultyId = 11, NameArabic = "الصيدلة السريرية", NameEnglish = "Clinical Pharmacy", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Clinical pharmaceutical care" },
    new StandardMajor { Id = 43, StandardFacultyId = 11, NameArabic = "الصيدلة الصناعية", NameEnglish = "Industrial Pharmacy", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Pharmaceutical manufacturing" },
    new StandardMajor { Id = 44, StandardFacultyId = 11, NameArabic = "الصيدلة الحيوية", NameEnglish = "Biopharmacy", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Biological pharmaceutical studies" },

    // Allied Health Sciences (12)
    new StandardMajor { Id = 45, StandardFacultyId = 12, NameArabic = "العلاج الطبيعي", NameEnglish = "Physical Therapy", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Physical rehabilitation" },
    new StandardMajor { Id = 46, StandardFacultyId = 12, NameArabic = "المختبرات الطبية", NameEnglish = "Medical Laboratory", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Medical testing and analysis" },
    new StandardMajor { Id = 47, StandardFacultyId = 12, NameArabic = "الأشعة التشخيصية", NameEnglish = "Diagnostic Radiology", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Medical imaging" },
    new StandardMajor { Id = 48, StandardFacultyId = 12, NameArabic = "التغذية العلاجية", NameEnglish = "Clinical Nutrition", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Nutritional therapy" },

    // Architecture (13)
    new StandardMajor { Id = 49, StandardFacultyId = 13, NameArabic = "العمارة", NameEnglish = "Architecture", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "Building design and planning" },
    new StandardMajor { Id = 50, StandardFacultyId = 13, NameArabic = "التصميم الداخلي", NameEnglish = "Interior Design", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Interior space design" },
    new StandardMajor { Id = 51, StandardFacultyId = 13, NameArabic = "تخطيط المدن", NameEnglish = "Urban Planning", StudyDuration = 5, HighSchoolPath = "Scientific", Description = "City planning and development" },
    new StandardMajor { Id = 52, StandardFacultyId = 13, NameArabic = "تصميم المناظر الطبيعية", NameEnglish = "Landscape Architecture", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Environmental design" },

    // Computing Sciences and Engineering (14)
    new StandardMajor { Id = 53, StandardFacultyId = 14, NameArabic = "علوم الحاسوب", NameEnglish = "Computer Science", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Programming and computer theory" },
    new StandardMajor { Id = 54, StandardFacultyId = 14, NameArabic = "هندسة الحاسوب", NameEnglish = "Computer Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Software development and systems" },
    new StandardMajor { Id = 55, StandardFacultyId = 14, NameArabic = "نظم المعلومات", NameEnglish = "Information Systems", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Business information technology" },
    new StandardMajor { Id = 56, StandardFacultyId = 14, NameArabic = "أمن المعلومات", NameEnglish = "Information Security", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Cybersecurity and data protection" },

    // Public Health (15)
    new StandardMajor { Id = 57, StandardFacultyId = 15, NameArabic = "الصحة العامة", NameEnglish = "Public Health", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Community health programs" },
    new StandardMajor { Id = 58, StandardFacultyId = 15, NameArabic = "صحة البيئة", NameEnglish = "Environmental Health", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Environmental health factors" },
    new StandardMajor { Id = 59, StandardFacultyId = 15, NameArabic = "الوبائيات", NameEnglish = "Epidemiology", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Disease patterns and control" },
    new StandardMajor { Id = 60, StandardFacultyId = 15, NameArabic = "تعزيز الصحة", NameEnglish = "Health Promotion", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Health education and awareness" },

    // Life Sciences (16)
    new StandardMajor { Id = 61, StandardFacultyId = 16, NameArabic = "التقنية الحيوية", NameEnglish = "Biotechnology", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Biological technology applications" },
    new StandardMajor { Id = 62, StandardFacultyId = 16, NameArabic = "علم الأحياء الدقيقة", NameEnglish = "Microbiology", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Study of microorganisms" },
    new StandardMajor { Id = 63, StandardFacultyId = 16, NameArabic = "علم الوراثة", NameEnglish = "Genetics", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Genetic studies and research" },
    new StandardMajor { Id = 64, StandardFacultyId = 16, NameArabic = "العلوم البيئية", NameEnglish = "Environmental Science", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Environmental studies" },

    // Graduate Studies (17)
    new StandardMajor { Id = 65, StandardFacultyId = 17, NameArabic = "إدارة الأعمال التنفيذية", NameEnglish = "Executive MBA", StudyDuration = 2, HighSchoolPath = "Both", Description = "Advanced business administration" },
    new StandardMajor { Id = 66, StandardFacultyId = 17, NameArabic = "القيادة التربوية", NameEnglish = "Educational Leadership", StudyDuration = 2, HighSchoolPath = "Both", Description = "Educational management" },
    new StandardMajor { Id = 67, StandardFacultyId = 17, NameArabic = "الهندسة المتقدمة", NameEnglish = "Advanced Engineering", StudyDuration = 2, HighSchoolPath = "Scientific", Description = "Advanced engineering studies" },
    new StandardMajor { Id = 68, StandardFacultyId = 17, NameArabic = "العلوم التطبيقية", NameEnglish = "Applied Sciences", StudyDuration = 2, HighSchoolPath = "Scientific", Description = "Advanced scientific research" },

    // Nursing (18)
    new StandardMajor { Id = 69, StandardFacultyId = 18, NameArabic = "التمريض العام", NameEnglish = "General Nursing", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "General nursing care" },
    new StandardMajor { Id = 70, StandardFacultyId = 18, NameArabic = "تمريض الطوارئ", NameEnglish = "Emergency Nursing", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Emergency care nursing" },
    new StandardMajor { Id = 71, StandardFacultyId = 18, NameArabic = "تمريض الأطفال", NameEnglish = "Pediatric Nursing", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Children's healthcare" },
    new StandardMajor { Id = 72, StandardFacultyId = 18, NameArabic = "تمريض الباطني والجراحة", NameEnglish = "Medical-Surgical Nursing", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Surgical care nursing" },

    // Islamic Studies (19)
    new StandardMajor { Id = 73, StandardFacultyId = 19, NameArabic = "الدراسات الإسلامية", NameEnglish = "Islamic Studies", StudyDuration = 4, HighSchoolPath = "Both", Description = "Comprehensive Islamic studies" },
    new StandardMajor { Id = 74, StandardFacultyId = 19, NameArabic = "الاقتصاد الإسلامي", NameEnglish = "Islamic Economics", StudyDuration = 4, HighSchoolPath = "Both", Description = "Islamic economic principles" },
    new StandardMajor { Id = 75, StandardFacultyId = 19, NameArabic = "الدعوة والثقافة الإسلامية", NameEnglish = "Islamic Culture", StudyDuration = 4, HighSchoolPath = "Both", Description = "Islamic cultural studies" },
    new StandardMajor { Id = 76, StandardFacultyId = 19, NameArabic = "التاريخ الإسلامي", NameEnglish = "Islamic History", StudyDuration = 4, HighSchoolPath = "Both", Description = "History of Islam" },

    // Arts and Media (20)
    new StandardMajor { Id = 77, StandardFacultyId = 20, NameArabic = "الإعلام", NameEnglish = "Media Studies", StudyDuration = 4, HighSchoolPath = "Both", Description = "Mass communication" },
    new StandardMajor { Id = 78, StandardFacultyId = 20, NameArabic = "الفنون البصرية", NameEnglish = "Visual Arts", StudyDuration = 4, HighSchoolPath = "Both", Description = "Visual artistic expression" },
    new StandardMajor { Id = 79, StandardFacultyId = 20, NameArabic = "التصميم الجرافيكي", NameEnglish = "Graphic Design", StudyDuration = 4, HighSchoolPath = "Both", Description = "Visual communication design" },
    new StandardMajor { Id = 80, StandardFacultyId = 20, NameArabic = "الإنتاج الإعلامي", NameEnglish = "Media Production", StudyDuration = 4, HighSchoolPath = "Both", Description = "Media content creation" }
);       
    }
}