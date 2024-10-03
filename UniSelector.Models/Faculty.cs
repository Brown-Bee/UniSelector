using System.ComponentModel.DataAnnotations.Schema;

namespace UniSelector.Models
{
    public class Faculty
    {
        // we need to make sure that the User don't duplicate the faculty

        public int Id { get; set; }
        public int StandardFacultyId { get; set; }
        [ForeignKey("StandardFacultyId")]
        public StandardFaculty StandardFaculty { get; set; }
        public int Credits { get; set; }
        public decimal AveragePrice { get; set; }
        public int UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public University? University { get; set; }
    }
}
