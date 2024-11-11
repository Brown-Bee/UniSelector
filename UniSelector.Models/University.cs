using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniSelector.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "University Name")]
        public string Name { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; } // Public/Private
        public string FullDescription { get; set; } // For detailed view
        public string SmallDescription { get; set; } // For cards/previews
        public string location { get; set; }
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        
        [EmailAddress]
        [NotMapped]
        public string Email { get; set; }
        
        [Range(1,30)]
        public int KuwaitRank { get; set; }
        [ValidateNever]
        public decimal Budget { get; set; }
        public string? ImageUrl { get; set; }
        public List<StudentRequest> AcceptedStudents { get; set; } = new List<StudentRequest>();
        public ICollection<Faculty> Faculties { get; set; } = new Collection<Faculty>();

        
    }
}
