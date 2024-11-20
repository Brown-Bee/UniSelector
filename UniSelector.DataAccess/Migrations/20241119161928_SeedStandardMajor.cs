using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedStandardMajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StandardMajors",
                columns: new[] { "Id", "Description", "HighSchoolPath", "NameArabic", "NameEnglish", "StandardFacultyId", "StudyDuration" },
                values: new object[,]
                {
                    { 1, "Focuses on electrical systems, power generation, and electronics", "Scientific", "الهندسة الكهربائية", "Electrical Engineering", 1, 4 },
                    { 2, "Deals with design and construction of infrastructure", "Scientific", "الهندسة المدنية", "Civil Engineering", 1, 4 },
                    { 3, "Studies mechanics, robotics, and thermal systems", "Scientific", "الهندسة الميكانيكية", "Mechanical Engineering", 1, 4 },
                    { 4, "Focuses on chemical processes and materials", "Scientific", "الهندسة الكيميائية", "Chemical Engineering", 1, 4 },
                    { 5, "Complete medical education program", "Scientific", "الطب العام", "General Medicine", 2, 7 },
                    { 6, "Specializes in child healthcare", "Scientific", "طب الأطفال", "Pediatrics", 2, 7 },
                    { 7, "Focus on surgical procedures and care", "Scientific", "الجراحة", "Surgery", 2, 7 },
                    { 8, "Emergency medical care and treatment", "Scientific", "طب الطوارئ", "Emergency Medicine", 2, 7 },
                    { 9, "Study of matter and energy", "Scientific", "الفيزياء", "Physics", 3, 4 },
                    { 10, "Study of chemical compounds and reactions", "Scientific", "الكيمياء", "Chemistry", 3, 4 },
                    { 11, "Study of living organisms", "Scientific", "الأحياء", "Biology", 3, 4 },
                    { 12, "Advanced mathematical studies", "Scientific", "الرياضيات", "Mathematics", 3, 4 },
                    { 13, "Financial accounting and auditing", "Both", "المحاسبة", "Accounting", 4, 4 },
                    { 14, "Marketing strategies and consumer behavior", "Both", "التسويق", "Marketing", 4, 4 },
                    { 15, "Business operations and strategy", "Both", "إدارة الأعمال", "Business Management", 4, 4 },
                    { 16, "Financial management and investment", "Both", "التمويل", "Finance", 4, 4 },
                    { 17, "English linguistics and literature", "Both", "اللغة الإنجليزية", "English Language", 5, 4 },
                    { 18, "Arabic linguistics and literature", "Both", "اللغة العربية", "Arabic Language", 5, 4 },
                    { 19, "Historical studies and research", "Literary", "التاريخ", "History", 5, 4 },
                    { 20, "Philosophical studies and ethics", "Literary", "الفلسفة", "Philosophy", 5, 4 },
                    { 21, "Primary school teaching", "Both", "التربية الابتدائية", "Elementary Education", 6, 4 },
                    { 22, "Special needs education", "Both", "التربية الخاصة", "Special Education", 6, 4 },
                    { 23, "English language teaching", "Both", "تعليم اللغة الإنجليزية", "English Education", 6, 4 },
                    { 24, "Mathematics teaching", "Scientific", "تعليم الرياضيات", "Mathematics Education", 6, 4 },
                    { 25, "Islamic law and jurisprudence", "Both", "الفقه الإسلامي", "Islamic Jurisprudence", 7, 4 },
                    { 26, "Islamic theology and doctrine", "Both", "أصول الدين", "Islamic Theology", 7, 4 },
                    { 27, "Quran interpretation and sciences", "Both", "الدراسات القرآنية", "Quranic Studies", 7, 4 },
                    { 28, "Study of prophetic traditions", "Both", "الحديث وعلومه", "Hadith Studies", 7, 4 },
                    { 29, "Constitutional and administrative law", "Both", "القانون العام", "Public Law", 8, 4 },
                    { 30, "Civil and commercial law", "Both", "القانون الخاص", "Private Law", 8, 4 },
                    { 31, "Criminal law and procedure", "Both", "القانون الجنائي", "Criminal Law", 8, 4 },
                    { 32, "International legal systems", "Both", "القانون الدولي", "International Law", 8, 4 },
                    { 33, "Human behavior and mental processes", "Both", "علم النفس", "Psychology", 9, 4 },
                    { 34, "Study of human society", "Both", "علم الاجتماع", "Sociology", 9, 4 },
                    { 35, "Community service and welfare", "Both", "الخدمة الاجتماعية", "Social Work", 9, 4 },
                    { 36, "Political systems and relations", "Both", "العلوم السياسية", "Political Science", 9, 4 },
                    { 37, "Comprehensive dental care", "Scientific", "طب الأسنان العام", "General Dentistry", 10, 5 },
                    { 38, "Dental surgical procedures", "Scientific", "جراحة الفم والأسنان", "Oral Surgery", 10, 5 },
                    { 39, "Dental alignment and correction", "Scientific", "تقويم الأسنان", "Orthodontics", 10, 5 },
                    { 40, "Children's dental care", "Scientific", "طب أسنان الأطفال", "Pediatric Dentistry", 10, 5 },
                    { 41, "Pharmaceutical sciences", "Scientific", "الصيدلة العامة", "General Pharmacy", 11, 5 },
                    { 42, "Clinical pharmaceutical care", "Scientific", "الصيدلة السريرية", "Clinical Pharmacy", 11, 5 },
                    { 43, "Pharmaceutical manufacturing", "Scientific", "الصيدلة الصناعية", "Industrial Pharmacy", 11, 5 },
                    { 44, "Biological pharmaceutical studies", "Scientific", "الصيدلة الحيوية", "Biopharmacy", 11, 5 },
                    { 45, "Physical rehabilitation", "Scientific", "العلاج الطبيعي", "Physical Therapy", 12, 4 },
                    { 46, "Medical testing and analysis", "Scientific", "المختبرات الطبية", "Medical Laboratory", 12, 4 },
                    { 47, "Medical imaging", "Scientific", "الأشعة التشخيصية", "Diagnostic Radiology", 12, 4 },
                    { 48, "Nutritional therapy", "Scientific", "التغذية العلاجية", "Clinical Nutrition", 12, 4 },
                    { 49, "Building design and planning", "Scientific", "العمارة", "Architecture", 13, 5 },
                    { 50, "Interior space design", "Scientific", "التصميم الداخلي", "Interior Design", 13, 4 },
                    { 51, "City planning and development", "Scientific", "تخطيط المدن", "Urban Planning", 13, 5 },
                    { 52, "Environmental design", "Scientific", "تصميم المناظر الطبيعية", "Landscape Architecture", 13, 4 },
                    { 53, "Programming and computer theory", "Scientific", "علوم الحاسوب", "Computer Science", 14, 4 },
                    { 54, "Software development and systems", "Scientific", "هندسة البرمجيات", "Software Engineering", 14, 4 },
                    { 55, "Business information technology", "Scientific", "نظم المعلومات", "Information Systems", 14, 4 },
                    { 56, "Cybersecurity and data protection", "Scientific", "أمن المعلومات", "Information Security", 14, 4 },
                    { 57, "Community health programs", "Scientific", "الصحة العامة", "Public Health", 15, 4 },
                    { 58, "Environmental health factors", "Scientific", "صحة البيئة", "Environmental Health", 15, 4 },
                    { 59, "Disease patterns and control", "Scientific", "الوبائيات", "Epidemiology", 15, 4 },
                    { 60, "Health education and awareness", "Scientific", "تعزيز الصحة", "Health Promotion", 15, 4 },
                    { 61, "Biological technology applications", "Scientific", "التقنية الحيوية", "Biotechnology", 16, 4 },
                    { 62, "Study of microorganisms", "Scientific", "علم الأحياء الدقيقة", "Microbiology", 16, 4 },
                    { 63, "Genetic studies and research", "Scientific", "علم الوراثة", "Genetics", 16, 4 },
                    { 64, "Environmental studies", "Scientific", "العلوم البيئية", "Environmental Science", 16, 4 },
                    { 65, "Advanced business administration", "Both", "إدارة الأعمال التنفيذية", "Executive MBA", 17, 2 },
                    { 66, "Educational management", "Both", "القيادة التربوية", "Educational Leadership", 17, 2 },
                    { 67, "Advanced engineering studies", "Scientific", "الهندسة المتقدمة", "Advanced Engineering", 17, 2 },
                    { 68, "Advanced scientific research", "Scientific", "العلوم التطبيقية", "Applied Sciences", 17, 2 },
                    { 69, "General nursing care", "Scientific", "التمريض العام", "General Nursing", 18, 4 },
                    { 70, "Emergency care nursing", "Scientific", "تمريض الطوارئ", "Emergency Nursing", 18, 4 },
                    { 71, "Children's healthcare", "Scientific", "تمريض الأطفال", "Pediatric Nursing", 18, 4 },
                    { 72, "Surgical care nursing", "Scientific", "تمريض الباطني والجراحة", "Medical-Surgical Nursing", 18, 4 },
                    { 73, "Comprehensive Islamic studies", "Both", "الدراسات الإسلامية", "Islamic Studies", 19, 4 },
                    { 74, "Islamic economic principles", "Both", "الاقتصاد الإسلامي", "Islamic Economics", 19, 4 },
                    { 75, "Islamic cultural studies", "Both", "الدعوة والثقافة الإسلامية", "Islamic Culture", 19, 4 },
                    { 76, "History of Islam", "Both", "التاريخ الإسلامي", "Islamic History", 19, 4 },
                    { 77, "Mass communication", "Both", "الإعلام", "Media Studies", 20, 4 },
                    { 78, "Visual artistic expression", "Both", "الفنون البصرية", "Visual Arts", 20, 4 },
                    { 79, "Visual communication design", "Both", "التصميم الجرافيكي", "Graphic Design", 20, 4 },
                    { 80, "Media content creation", "Both", "الإنتاج الإعلامي", "Media Production", 20, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "StandardMajors",
                keyColumn: "Id",
                keyValue: 80);
        }
    }
}
