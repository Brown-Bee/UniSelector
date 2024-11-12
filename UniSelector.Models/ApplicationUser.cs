using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UniSelector.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Basic Info
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [DisplayName("Civil ID")]
        public string? CivilID { get; set; }

        // Personal Details
        public string Gender { get; set; }

        [DisplayName("Marital Status")]
        public string? MaritalStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Place of Birth")]
        public string? PlaceOfBirth { get; set; }

        // Nationality Info
        public string? Nationality { get; set; }

        [DisplayName("Mother's Nationality")]
        public string? MothersNationality { get; set; }

        // Address Details
        public string? Address { get; set; }

        // Education Details
        [DisplayName("High School Type")]
        public string? HighSchoolType { get; set; }  // Scientific, Literary etc

        [Range(0, 100)]
        [DisplayName("High School Grade")]
        public float? Grade { get; set; }

        [DisplayName("High School Graduation Year")]
        [Range(1900, 2024)] // We can update the max year dynamically
        public int? HighSchoolGraduationYear { get; set; }

        [DisplayName("Is Public School")]
        public bool IsPublicSchool { get; set; }

        [DisplayName("Has 4 Years Experience")]
        public bool HasFourYearExperience { get; set; }

        // Document Info
        [DisplayName("Civil ID Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime? CivilIDExpiryDate { get; set; }

        // Extra Qualifications
        [Range(0, 9)]
        [DisplayName("IELTS Score")]
        public float? IELTS { get; set; }

        [Range(0, 120)]
        [DisplayName("TOEFL Score")]
        public float? TOEFL { get; set; }

        [DisplayName("Has Aptitude Test")]
        public bool HasAptitudeTest { get; set; }
    }
}