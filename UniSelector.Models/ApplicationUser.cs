using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace UniSelector.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public float? Grade { get; set; }
        [DataType(DataType.Date)] 
        public DateTime BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? PlaceOfBirth { get; set; }
        public int? HighSchoolGraduationYear { get; set; }

    }
}
