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
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
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
                    CareerOptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "StudetsRequests",
                columns: table => new
                {
                    StudentRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IELTS = table.Column<float>(type: "real", nullable: true),
                    TOEFL = table.Column<float>(type: "real", nullable: true),
                    KUAcademicAptitudeTests = table.Column<bool>(type: "bit", nullable: true),
                    UnibersityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudetsRequests", x => x.StudentRequestId);
                    table.ForeignKey(
                        name: "FK_StudetsRequests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudetsRequests_Universities_UnibersityId",
                        column: x => x.UnibersityId,
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
                    MarketDemand = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Scifi" },
                    { 3, 3, "History" }
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
                columns: new[] { "Id", "Budget", "FullDescription", "ImageUrl", "KuwaitRank", "Name", "PhoneNumber", "SmallDescription", "location", "type" },
                values: new object[,]
                {
                    { 1, 4500m, "A leading open education institution in the Arab world.", "/images/University/AOU.png", 1, "Arab Open University (AOU)", "99999999", "", "العارضية-Ardya", "Private" },
                    { 2, 25000m, "Offering American-style education with a Middle Eastern perspective.", "/images/University/AUM.png", 2, "American University In Middle East (AUM)", "99999999", "", "العقيلة-Egila", "Private" },
                    { 3, 15000m, "Providing a comprehensive American liberal arts education.", "/images/University/AUK.png", 3, "American University Of Kuwait (AUK)", "99999999", "", "السالمية-Salmya", "Private" },
                    { 4, 13000m, "The premier public institution of higher education in Kuwait.", "/images/university/KU.png", 4, "Kuwait University (KU)", "99999999", "", "الشويخ-Shwaikh", "Public" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", 2, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SWD9999001", "", 99.0, 90.0, 80.0, 85.0, "Fortune of Time" },
                    { 2, "Nancy Hoover", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "CAW777777701", "", 40.0, 30.0, 20.0, 25.0, "Dark Skies" },
                    { 3, "Julian Button", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "RITO5555501", "", 55.0, 50.0, 35.0, 40.0, "Vanish in the Sunset" },
                    { 4, "Abby Muscles", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", "", 70.0, 65.0, 55.0, 60.0, "Cotton Candy" },
                    { 5, "Ron Parker", 2, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", "", 30.0, 27.0, 20.0, 25.0, "Rock in the Ocean" },
                    { 6, "Laura Phantom", 1, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "", 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" }
                });

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
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardMajors_StandardFacultyId",
                table: "StandardMajors",
                column: "StandardFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_ApplicationUserId",
                table: "StudetsRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudetsRequests_UnibersityId",
                table: "StudetsRequests",
                column: "UnibersityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Products");

            migrationBuilder.DropTable(
                name: "StudetsRequests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "StandardMajors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "StandardFaculties");
        }
    }
}
