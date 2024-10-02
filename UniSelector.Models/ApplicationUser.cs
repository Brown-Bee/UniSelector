using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace UniSelector.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Adress { get; set; }
        public float? Grade { get; set; }
        public string? Nationality { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateFormat? DateOfBirth { get; set; }
        public int? HighSchoolGraduationYear { get; set; }

    }
}
