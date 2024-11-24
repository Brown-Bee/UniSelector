using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniSelector.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CivilID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighSchoolType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<float>(type: "real", nullable: true),
                    HighSchoolGraduationYear = table.Column<int>(type: "int", nullable: true),
                    IsPublicSchool = table.Column<bool>(type: "bit", nullable: false),
                    HasFourYearExperience = table.Column<bool>(type: "bit", nullable: false),
                    CivilIDExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IELTS = table.Column<float>(type: "real", nullable: true),
                    TOEFL = table.Column<float>(type: "real", nullable: true),
                    HasAptitudeTest = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandardFaculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardFaculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KuwaitRank = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardMajors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyDuration = table.Column<int>(type: "int", nullable: false),
                    HighSchoolPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardFacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardMajors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardMajors_StandardFaculties_StandardFacultyId",
                        column: x => x.StandardFacultyId,
                        principalTable: "StandardFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardFacultyId = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_StandardFaculties_StandardFacultyId",
                        column: x => x.StandardFacultyId,
                        principalTable: "StandardFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumGrade = table.Column<float>(type: "real", nullable: false),
                    MinimumIELTS = table.Column<float>(type: "real", nullable: true),
                    MinimumTOEFL = table.Column<float>(type: "real", nullable: true),
                    RequiresAptitudeTest = table.Column<bool>(type: "bit", nullable: false),
                    EmploymentRate = table.Column<float>(type: "real", nullable: false),
                    AverageStartingSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StandardMajorId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Majors_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Majors_StandardMajors_StandardMajorId",
                        column: x => x.StandardMajorId,
                        principalTable: "StandardMajors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityFeedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilIdPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighSchoolCertificatePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCivilIdVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsPassportVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsHighSchoolCertificateVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    IsProfileComplete = table.Column<bool>(type: "bit", nullable: false),
                    MeetsRequirements = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    MajorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "StandardFaculties",
                columns: new[] { "Id", "NameArabic", "NameEnglish" },
                values: new object[,]
                {
                    { 1, "كلية الهندسة", "College of Engineering" },
                    { 2, "كلية الطب", "College of Medicine" },
                    { 3, "كلية العلوم", "College of Science" },
                    { 4, "كلية إدارة الأعمال", "College of Business Administration" },
                    { 5, "كلية الآداب", "College of Arts" },
                    { 6, "كلية التربية", "College of Education" },
                    { 7, "كلية الشريعة والدراسات الإسلامية", "College of Sharia and Islamic Studies" },
                    { 8, "كلية الحقوق", "College of Law" },
                    { 9, "كلية العلوم الاجتماعية", "College of Social Sciences" },
                    { 10, "كلية طب الأسنان", "College of Dentistry" },
                    { 11, "كلية الصيدلة", "College of Pharmacy" },
                    { 12, "كلية العلوم الطبية المساعدة", "College of Allied Health Sciences" },
                    { 13, "كلية العمارة", "College of Architecture" },
                    { 14, "كلية علوم وهندسة الحاسوب", "College of Computing Sciences and Engineering" },
                    { 15, "كلية الصحة العامة", "College of Public Health" },
                    { 16, "كلية العلوم الحياتية", "College of Life Sciences" },
                    { 17, "كلية الدراسات العليا", "College of Graduate Studies" },
                    { 18, "كلية التمريض", "College of Nursing" },
                    { 19, "كلية الدراسات الإسلامية", "College of Islamic Studies" },
                    { 20, "كلية الفنون والإعلام", "College of Arts and Media" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "FullDescription", "ImageUrl", "KuwaitRank", "Name", "PhoneNumber", "SmallDescription", "location", "type" },
                values: new object[,]
                {
                    { 1, "A leading open education institution in the Arab world.", "/images/University/AOU.png", 1, "Arab Open University (AOU)", "99999999", "", "العارضية-Ardya", "Private" },
                    { 2, "Offering American-style education with a Middle Eastern perspective.", "/images/University/AUM.png", 2, "American University In Middle East (AUM)", "99999999", "", "العقيلة-Egila", "Private" },
                    { 3, "Providing a comprehensive American liberal arts education.", "/images/University/AUK.png", 3, "American University Of Kuwait (AUK)", "99999999", "", "السالمية-Salmya", "Private" },
                    { 4, "The premier public institution of higher education in Kuwait.", "/images/university/KU.png", 4, "Kuwait University (KU)", "99999999", "", "الشويخ-Shwaikh", "Public" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Applications_FacultyId",
                table: "Applications",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_MajorId",
                table: "Applications",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UniversityId",
                table: "Applications",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_StandardFacultyId",
                table: "Faculties",
                column: "StandardFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_FacultyId",
                table: "Majors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_StandardMajorId",
                table: "Majors",
                column: "StandardMajorId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardMajors_StandardFacultyId",
                table: "StandardMajors",
                column: "StandardFacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "StandardMajors");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "StandardFaculties");
        }
    }
}
