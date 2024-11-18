using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniSelector.Models;

public class Major
{
    public int Id { get; set; }

    // Basic Info
    public int Credits { get; set; }
    public decimal AveragePrice { get; set; }

    [Range(0, 100)]
    public float MinimumGrade { get; set; }


    // Testing Requirements
    [Range(0, 9)]
    public float? MinimumIELTS { get; set; }

    [Range(0, 120)]
    public float? MinimumTOEFL { get; set; }

    public bool RequiresAptitudeTest { get; set; }

    // Job Market Info
    [Range(0, 100)]
    public float EmploymentRate { get; set; }

    public decimal AverageStartingSalary { get; set; }


    // Relationships
    public int StandardMajorId { get; set; }
    [ForeignKey("StandardMajorId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public StandardMajor? StandardMajor { get; set; }
    
    public int FacultyId { get; set; }
    [ForeignKey("FacultyId")]
    public Faculty? Faculty { get; set; }
}