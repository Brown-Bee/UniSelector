using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniSelector.Models
{
    public class StudentRequest
    {
        public int StudentRequestId { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }

        public float? IELTS { get; set; }
        public float? TOEFL { get; set; }
        [DisplayName("امتحان القدرات\\KU Academic Aptitude Tests")]
        public bool? KUAcademicAptitudeTests { get; set; }
        public int UnibersityId { get; set; }
        [ForeignKey("UnibersityId")]    
        public University University { get; set; }
    }
}
