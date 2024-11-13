using System.ComponentModel.DataAnnotations.Schema;

namespace UniSelector.Models;

public class Major
{
    public int Id { get; set; }
    public int Credits { get; set; }
    public decimal AveragePrice { get; set; }


    public int StandardMajorId { get; set; }
    [ForeignKey("StandardMajorId")]
    public StandardMajor? StandardMajor { get; set; }


    public int FacultyId { get; set; }
    [ForeignKey("FacultyId")]
    public Faculty? Faculty { get; set; }
}