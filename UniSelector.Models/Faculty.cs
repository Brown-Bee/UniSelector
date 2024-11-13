using System.ComponentModel.DataAnnotations.Schema;

namespace UniSelector.Models
{
    public class Faculty
    {
        // we need to make sure that the User don't duplicate the faculty

        public int Id { get; set; }

        // One-to-one with StandardFaculty
        public int StandardFacultyId { get; set; }
        [ForeignKey("StandardFacultyId")]
        public StandardFaculty? StandardFaculty { get; set; }
 
        public int UniversityId { get; set; }
        [ForeignKey("UniversityId")]
        public University? University { get; set; }

        // One-to-many with Major
        public ICollection<Major> Majors { get; set; } = new List<Major>();
    }
}
