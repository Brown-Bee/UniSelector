using System.ComponentModel.DataAnnotations.Schema;

namespace UniSelector.Models
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public University University { get; set; }
    }
}