using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        public string type { get; set; }
        public string Description { get; set; }
        public string location { get; set; }
        
        [Range(1,30)]
        public int KuwaitRank { get; set; }
        [ValidateNever]
        public decimal Budget { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<Faculty> Faculties { get; set; } = new Collection<Faculty>();

        public List<GalleryImage> GalleryImages { get; set; } = new List<GalleryImage>();
        
    }
}
