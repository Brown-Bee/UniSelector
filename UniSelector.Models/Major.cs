using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UniSelector.Models;

public class Major
{
    public int Id { get; set; }

    // Basic Info
    public int Credits { get; set; }
    [DisplayName("Average Price")]
    public double AveragePrice { get; set; }
    [DisplayName("Minimum Grade")]
    [Range(0, 100)]
    public double MinimumGrade { get; set; }


    // Testing Requirements
    [DisplayName("Minimum IELTS")]
    [Range(0, 9)]
    public double? MinimumIELTS { get; set; }
    [DisplayName("Minimum TOEFL")]
    [Range(0, 120)]
    public double? MinimumTOEFL { get; set; }
    [DisplayName("Requires Aptitude Test")]
    public bool RequiresAptitudeTest { get; set; }

    // Job Market Info
    [DisplayName("Employment Rate")]
    [Range(0, 100)]
    public double EmploymentRate { get; set; }
    [DisplayName("Average Starting Salary")]
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