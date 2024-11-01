using System.ComponentModel.DataAnnotations.Schema;

namespace UniSelector.Models;

public class Major
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StandardFacultyId { get; set; }
    [ForeignKey("StandardFacultyId")]
    public StandardFaculty? StandardFaculty { get; set; }
}