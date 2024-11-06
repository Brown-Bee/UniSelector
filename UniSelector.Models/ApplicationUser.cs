  using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string UserType { get; set; }  // Student/University/Admin
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<StudentRequest> StudentRequests { get; set; }

    }
}
