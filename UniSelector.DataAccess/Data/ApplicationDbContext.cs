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

        modelBuilder.Entity<StandardMajor>().HasData(
    // Engineering (1)
    new StandardMajor { Id = 1, StandardFacultyId = 1, NameArabic = "الهندسة الكهربائية", NameEnglish = "Electrical Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Focuses on electrical systems, power generation, and electronics" },
    new StandardMajor { Id = 2, StandardFacultyId = 1, NameArabic = "الهندسة المدنية", NameEnglish = "Civil Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Deals with design and construction of infrastructure" },
    new StandardMajor { Id = 3, StandardFacultyId = 1, NameArabic = "الهندسة الميكانيكية", NameEnglish = "Mechanical Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Studies mechanics, robotics, and thermal systems" },
    new StandardMajor { Id = 4, StandardFacultyId = 1, NameArabic = "الهندسة الكيميائية", NameEnglish = "Chemical Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Focuses on chemical processes and materials" },

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
    new StandardMajor { Id = 54, StandardFacultyId = 14, NameArabic = "هندسة البرمجيات", NameEnglish = "Software Engineering", StudyDuration = 4, HighSchoolPath = "Scientific", Description = "Software development and systems" },
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
