using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniSelector.Models;

public class Major
{
    public int Id { get; set; }

    // Basic Info
    public int Credits { get; set; }
    public double AveragePrice { get; set; }
    
    [Range(0, 100)]
    public double MinimumGrade { get; set; }


    // Testing Requirements
    [Range(0, 9)]
    public double? MinimumIELTS { get; set; }

    [Range(0, 120)]
    public double? MinimumTOEFL { get; set; }

    public bool RequiresAptitudeTest { get; set; }

    // Job Market Info
    [Range(0, 100)]
    public double EmploymentRate { get; set; }

    public double AverageStartingSalary { get; set; }


    // Relationships
    public int StandardMajorId { get; set; }
    [ForeignKey("StandardMajorId")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public StandardMajor? StandardMajor { get; set; }
    
    public int FacultyId { get; set; }
    [ForeignKey("FacultyId")]
    public Faculty? Faculty { get; set; }
}