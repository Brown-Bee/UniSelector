using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using UniSelector.Models;

public class Application
{
    [Key]
    public int Id { get; set; }

    // User and University info
    public string UserId { get; set; }
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int MajorId { get; set; }

    // Application Details
    public DateTime ApplicationDate { get; set; }

    public string Status { get; set; } = "Pending";  // Pending/Accepted/Rejected

    public string? UniversityFeedback { get; set; }

    // Document URLs (stored locally)
    [ValidateNever]
    public string? CivilIdPath { get; set; }

    [ValidateNever]
    public string? PassportPath { get; set; }

    [ValidateNever]
    public string? HighSchoolCertificatePath { get; set; }

    // Document Verification
    public bool IsCivilIdVerified { get; set; }
    public bool IsPassportVerified { get; set; }
    public bool IsHighSchoolCertificateVerified { get; set; }

    // Navigation Properties
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser? User { get; set; }

    [ForeignKey("UniversityId")]
    [ValidateNever]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public University? University { get; set; }

    [ForeignKey("FacultyId")]
    [ValidateNever]
    public Faculty? Faculty { get; set; }

    [ForeignKey("MajorId")]
    [ValidateNever]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Major? Major { get; set; }
}