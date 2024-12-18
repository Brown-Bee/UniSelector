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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    AveragePrice = table.Column<double>(type: "float", nullable: false),
                    MinimumGrade = table.Column<double>(type: "float", nullable: false),
                    MinimumIELTS = table.Column<double>(type: "float", nullable: true),
                    MinimumTOEFL = table.Column<double>(type: "float", nullable: true),
                    RequiresAptitudeTest = table.Column<bool>(type: "bit", nullable: false),
                    AverageStartingSalary = table.Column<double>(type: "float", nullable: false),
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
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityFeedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CivilIdPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighSchoolCertificatePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCivilIdVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsPassportVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsHighSchoolCertificateVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsProfileComplete = table.Column<bool>(type: "bit", nullable: false),
                    UniEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "Id", "Email", "FullDescription", "ImageUrl", "KuwaitRank", "Name", "PhoneNumber", "SmallDescription", "location", "type" },
                values: new object[,]
                {
                    { 1, null, "Accredited liberal arts institution offering American-style education since 2004. Located in Salmiya, Kuwait's premier university district.", "/images/University/AUK.png", 1, "American University of Kuwait (AUK)", "1802040", "Kuwait's leading American-style liberal arts university", "Salmiya, Block 13, Salem Al Mubarak Street", "Private" },
                    { 2, null, "Leading engineering and business focused university established in 2008. Known for strong industry partnerships and state-of-the-art facilities.", "/images/University/AUM.png", 2, "American University of Middle East (AUM)", "+965 22251400", "Premier engineering and business education in Kuwait", "Egaila, Block 6, Salem Sabah Al-Salem Area", "Private" },
                    { 3, null, "First private university in Kuwait, established in 2002. Offers American-style education with focus on business and technology.", "/images/University/GUST.png", 3, "Gulf University for Science and Technology (GUST)", "25307000", "Kuwait's first private university for business and technology", "Mubarak Al-Abdullah Area, West Mishref", "Private" },
                    { 4, null, "Regional university focused on accessible education since 2002. Partners with UK Open University for international accreditation.", "/images/University/AOU.png", 4, "Arab Open University (AOU)", "24394400", "Accessible quality education across Kuwait", "Al-Ardiya, Block 3, Street 37", "Private" },
                    { 5, null, "Specialized institution focusing on engineering and technology education. Strong emphasis on practical skills and industry readiness.", "/images/University/KCST.png", 5, "Kuwait College of Science and Technology (KCST)", "24980450", "Advanced technical education in Kuwait", "Doha District, Block 4", "Private" },
                    { 6, null, "Australian-standard technical and vocational education. Strong focus on engineering and maritime studies.", "/images/University/AU.png", 6, "Australian University (AU)", "1828225", "Australian-standard technical education", "Mishref, Block 5", "Private" },
                    { 7, null, "Women's college offering Australian-standard education in business, design and technology.", "/images/University/BHCK.png", 7, "Box Hill College Kuwait", "23962000", "Quality education for women in Kuwait", "Abu Halifa, Block 1", "Private" },
                    { 8, null, "Specialized institution focused on legal education and jurisprudence studies.", "/images/University/KILAW.png", 8, "Kuwait International Law School", "22280111", "Premier legal education in Kuwait", "Doha, Block 2", "Private" },
                    { 9, null, "Specialized college offering aviation engineering and management programs.", "/images/University/CAT.png", 9, "College of Aviation Technology", "24315555", "Kuwait's aviation education hub", "Kuwait International Airport Area", "Private" },
                    { 10, null, "Modern technical college focusing on IT, business and telecommunications.", "/images/University/KTECH.png", 10, "Kuwait Technical College", "22280222", "Advanced technical education", "Shuwaikh Educational Area", "Private" },
                    { 11, null, "Established in 1966, Kuwait's first public university offering comprehensive education across multiple campuses", "/images/University/KU.png", 11, "Kuwait University", "24987000", "Kuwait's premier public higher education institution", "Multiple campuses - Main in Khaldiya", "Public" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "AdmissionRequirements", "Description", "StandardFacultyId", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Minimum 70% high school GPA, TOEFL 80+ or IELTS 6.5+", "Comprehensive liberal arts education with diverse programs in humanities and sciences", 5, 1 },
                    { 2, "Minimum 70% high school GPA, TOEFL 80+ or IELTS 6.5+", "AACSB-accredited business programs with focus on global business practices", 4, 1 },
                    { 3, "Minimum 75% high school GPA in Scientific track, Strong math/science background", "ABET-accredited engineering programs with state-of-the-art facilities", 1, 1 },
                    { 4, "Minimum 70% high school GPA, Portfolio submission required", "Creative design education with focus on practical applications", 13, 1 },
                    { 5, "Minimum 75% in Scientific track, Strong mathematics background", "Comprehensive engineering programs with modern laboratories", 14, 2 },
                    { 6, "Minimum 70% high school GPA, English proficiency required", "Industry-focused business education with international accreditation", 4, 2 },
                    { 7, "Minimum 70% GPA, TOEFL 79+ or IELTS 6.5+", "Comprehensive programs in humanities, media, and computer science", 5, 3 },
                    { 8, "Minimum 70% GPA, English proficiency required", "AACSB-accredited business school with focus on practical skills", 4, 3 },
                    { 9, "Minimum 75% in Scientific stream, Strong math background", "Advanced technical education in engineering and computing", 14, 5 },
                    { 10, "Minimum 60% GPA, Basic English proficiency", "Flexible business education with UK partnership", 4, 4 },
                    { 11, "Minimum 65% GPA, Basic programming knowledge preferred", "IT and computing programs with international recognition", 14, 4 },
                    { 12, "Minimum 75% in Scientific track, Mathematics proficiency", "Australian-standard engineering education", 1, 6 },
                    { 13, "Minimum 70% GPA, English proficiency required", "Business programs with Australian curriculum", 4, 6 },
                    { 14, "Minimum 65% GPA, English proficiency test", "Women's business education with Australian standards", 4, 7 },
                    { 15, "Portfolio submission, Interview required", "Creative arts and design programs for women", 20, 7 },
                    { 16, "Minimum 75% GPA, Arabic and English proficiency", "Comprehensive legal education with focus on Kuwait and international law", 8, 8 },
                    { 17, "Minimum 75% in Scientific track, English proficiency required", "Specialized aviation engineering and maintenance programs", 1, 9 },
                    { 18, "Minimum 65% GPA, Basic technical aptitude", "Technical IT and networking education", 14, 10 },
                    { 19, "Minimum 65% GPA, English proficiency test", "Applied business and management programs", 4, 10 },
                    { 20, "Minimum 60% GPA, Higher English proficiency required", "English language and literature studies with focus on linguistics and translation", 5, 4 },
                    { 21, "Minimum 80% in Scientific track, Aptitude test required", "Leading engineering programs with ABET accreditation", 1, 11 },
                    { 22, "Minimum 75% in Scientific track, Aptitude test required", "Research-focused science programs across multiple disciplines", 3, 11 },
                    { 23, "Minimum 90% in Scientific track, Aptitude test required", "Premier medical education in Kuwait", 2, 11 },
                    { 24, "Minimum 75% in Scientific track, Aptitude test required", "Healthcare professional programs with clinical training", 12, 11 },
                    { 25, "Minimum 85% in Scientific track, Aptitude test required", "PharmD program with extensive clinical training", 11, 11 },
                    { 26, "Minimum 85% in Scientific track, Aptitude test required", "Advanced dental education with modern facilities", 10, 11 },
                    { 27, "Minimum 75% in Either track, Aptitude test required", "AACSB-accredited business programs", 4, 11 },
                    { 28, "Minimum 70% in Either track, Aptitude test required", "Comprehensive humanities and social sciences programs", 5, 11 },
                    { 29, "Minimum 80% in Either track, Aptitude test required", "Kuwait's premier legal education program", 8, 11 },
                    { 30, "Minimum 70% in Either track, Aptitude test required", "Teacher preparation and educational research programs", 6, 11 },
                    { 31, "Minimum 70% in Either track, Aptitude test required", "Islamic studies and jurisprudence programs", 7, 11 }
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
                    { 54, "Software development and systems", "Scientific", "هندسة الحاسوب", "Computer Engineering", 14, 4 },
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
                    { 80, "Media content creation", "Both", "الإنتاج الإعلامي", "Media Production", 20, 4 },
                    { 81, "Maritime engineering and naval architecture", "Scientific", "الهندسة البحرية", "Maritime Engineering", 1, 4 },
                    { 82, "Aircraft engineering and maintenance", "Scientific", "هندسة الطيران", "Aviation Engineering", 1, 4 },
                    { 83, "Aviation operations and management", "Both", "إدارة الطيران", "Aviation Management", 4, 4 },
                    { 84, "Electronics and telecommunications systems", "Scientific", "هندسة الإلكترونيات والاتصالات", "Electronics & Communications Engineering", 1, 4 },
                    { 85, "Human resource management and development", "Both", "إدارة الموارد البشرية", "Human Resources Management", 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "AveragePrice", "AverageStartingSalary", "Credits", "FacultyId", "MinimumGrade", "MinimumIELTS", "MinimumTOEFL", "RequiresAptitudeTest", "StandardMajorId" },
                values: new object[,]
                {
                    { 1, 16000.0, 800.0, 124, 1, 70.0, 6.5, 80.0, false, 17 },
                    { 2, 16000.0, 850.0, 124, 1, 70.0, 6.5, 80.0, false, 77 },
                    { 3, 17000.0, 1200.0, 130, 1, 75.0, 6.5, 80.0, true, 53 },
                    { 4, 16500.0, 1000.0, 128, 2, 70.0, 6.5, 80.0, false, 13 },
                    { 5, 16500.0, 1100.0, 128, 2, 70.0, 6.5, 80.0, false, 16 },
                    { 6, 16500.0, 950.0, 128, 2, 70.0, 6.5, 80.0, false, 15 },
                    { 7, 16500.0, 900.0, 128, 2, 70.0, 6.5, 80.0, false, 14 },
                    { 8, 18000.0, 1300.0, 140, 3, 75.0, 6.5, 80.0, true, 1 },
                    { 9, 18000.0, 1350.0, 140, 3, 75.0, 6.5, 80.0, true, 54 },
                    { 10, 18000.0, 1250.0, 140, 3, 75.0, 6.5, 80.0, true, 55 },
                    { 11, 19000.0, 1200.0, 140, 5, 75.0, 6.0, 80.0, true, 2 },
                    { 12, 19000.0, 1300.0, 140, 5, 75.0, 6.0, 80.0, true, 54 },
                    { 13, 19000.0, 1250.0, 140, 5, 75.0, 6.0, 80.0, true, 1 },
                    { 14, 19000.0, 1200.0, 140, 5, 75.0, 6.0, 80.0, true, 3 },
                    { 15, 19000.0, 1150.0, 140, 5, 75.0, 6.0, 80.0, true, 4 },
                    { 16, 17000.0, 900.0, 130, 6, 70.0, 6.0, 80.0, false, 13 },
                    { 17, 17000.0, 950.0, 130, 6, 70.0, 6.0, 80.0, false, 16 },
                    { 18, 17000.0, 850.0, 130, 6, 70.0, 6.0, 80.0, false, 14 },
                    { 19, 17000.0, 900.0, 130, 6, 70.0, 6.0, 80.0, false, 55 },
                    { 20, 16500.0, 800.0, 132, 7, 70.0, 6.5, 79.0, false, 77 },
                    { 21, 17500.0, 900.0, 132, 4, 70.0, 6.5, 80.0, true, 50 },
                    { 22, 17500.0, 850.0, 132, 4, 70.0, 6.5, 80.0, true, 79 },
                    { 23, 16500.0, 1100.0, 130, 7, 75.0, 6.5, 79.0, true, 53 },
                    { 24, 16500.0, 950.0, 130, 8, 70.0, 6.5, 79.0, false, 13 },
                    { 25, 16500.0, 1000.0, 130, 8, 70.0, 6.5, 79.0, false, 16 },
                    { 26, 16500.0, 900.0, 130, 8, 70.0, 6.5, 79.0, false, 15 },
                    { 27, 15500.0, 1100.0, 135, 9, 75.0, 6.0, 80.0, true, 54 },
                    { 28, 15500.0, 1000.0, 135, 9, 75.0, 6.0, 80.0, true, 84 },
                    { 29, 15000.0, 950.0, 130, 9, 70.0, 6.0, 80.0, false, 55 },
                    { 30, 12000.0, 750.0, 132, 10, 60.0, 5.5, 75.0, false, 15 },
                    { 31, 12000.0, 750.0, 132, 10, 60.0, 5.5, 75.0, false, 14 },
                    { 32, 12000.0, 800.0, 132, 10, 60.0, 5.5, 75.0, false, 13 },
                    { 33, 12000.0, 800.0, 132, 10, 60.0, 5.5, 75.0, false, 55 },
                    { 34, 12500.0, 850.0, 135, 11, 65.0, 5.5, 75.0, false, 55 },
                    { 35, 12000.0, 700.0, 132, 20, 60.0, 6.0, 78.0, false, 17 },
                    { 36, 16000.0, 1000.0, 140, 12, 70.0, 6.0, 78.0, true, 1 },
                    { 37, 15000.0, 850.0, 132, 13, 65.0, 6.0, 78.0, false, 15 },
                    { 38, 14000.0, 800.0, 130, 14, 65.0, 5.5, 75.0, false, 15 },
                    { 39, 14000.0, 750.0, 130, 15, 65.0, 5.5, 75.0, true, 79 },
                    { 40, 14500.0, 900.0, 132, 15, 65.0, 5.5, 75.0, false, 55 },
                    { 41, 16000.0, 1000.0, 140, 16, 75.0, 6.0, 78.0, false, 29 },
                    { 42, 18000.0, 1200.0, 140, 17, 75.0, 6.0, 80.0, true, 82 },
                    { 43, 17000.0, 1000.0, 135, 17, 70.0, 6.0, 80.0, false, 83 },
                    { 44, 13000.0, 850.0, 130, 18, 65.0, 5.5, 75.0, false, 55 },
                    { 45, 13000.0, 800.0, 130, 19, 65.0, 5.5, 75.0, false, 15 },
                    { 46, 0.0, 1200.0, 144, 21, 80.0, null, null, true, 4 },
                    { 47, 0.0, 1200.0, 144, 21, 80.0, null, null, true, 2 },
                    { 48, 0.0, 1300.0, 144, 21, 80.0, null, null, true, 54 },
                    { 49, 0.0, 1250.0, 144, 21, 80.0, null, null, true, 1 },
                    { 50, 0.0, 1200.0, 144, 21, 80.0, null, null, true, 3 },
                    { 51, 0.0, 900.0, 132, 22, 75.0, null, null, true, 12 },
                    { 52, 0.0, 850.0, 132, 22, 75.0, null, null, true, 9 },
                    { 53, 0.0, 900.0, 132, 22, 75.0, null, null, true, 10 },
                    { 54, 0.0, 850.0, 132, 22, 75.0, null, null, true, 11 },
                    { 55, 0.0, 2000.0, 220, 23, 90.0, null, null, true, 5 },
                    { 56, 0.0, 1100.0, 140, 24, 75.0, null, null, true, 45 },
                    { 57, 0.0, 1000.0, 135, 24, 75.0, null, null, true, 46 },
                    { 58, 0.0, 1500.0, 170, 25, 85.0, null, null, true, 41 },
                    { 59, 0.0, 1800.0, 180, 26, 85.0, null, null, true, 37 },
                    { 60, 0.0, 1100.0, 130, 27, 75.0, null, null, true, 13 },
                    { 61, 0.0, 1200.0, 130, 27, 75.0, null, null, true, 16 },
                    { 62, 0.0, 1000.0, 130, 27, 75.0, null, null, true, 15 },
                    { 63, 0.0, 1000.0, 130, 27, 75.0, null, null, true, 14 },
                    { 64, 0.0, 1100.0, 130, 27, 75.0, null, null, true, 55 },
                    { 65, 0.0, 800.0, 128, 28, 70.0, null, null, true, 18 },
                    { 66, 0.0, 850.0, 128, 28, 70.0, null, null, true, 17 },
                    { 67, 0.0, 900.0, 128, 28, 70.0, null, null, true, 77 },
                    { 68, 0.0, 1200.0, 138, 29, 80.0, null, null, true, 29 },
                    { 69, 0.0, 900.0, 132, 30, 70.0, null, null, true, 21 },
                    { 70, 0.0, 950.0, 132, 30, 70.0, null, null, true, 66 },
                    { 71, 0.0, 850.0, 132, 31, 70.0, null, null, true, 25 },
                    { 72, 0.0, 800.0, 132, 31, 70.0, null, null, true, 26 },
                    { 73, 0.0, 800.0, 132, 31, 70.0, null, null, true, 27 },
                    { 74, 0.0, 800.0, 132, 31, 70.0, null, null, true, 28 }
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
