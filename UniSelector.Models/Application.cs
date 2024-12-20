﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using UniSelector.Models;

public class Application
{
    [Key]
    public int Id { get; set; }

    // Application Details
    public DateTime ApplicationDate { get; set; } = DateTime.Now;

    public string Response { get; set; } = "Pending";  // Pending/Accepted/Rejected
    public string Status { get; set; }  // Draft/Posted/Cancelled
    
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
    public bool IsProfileComplete { get; set; }

    // User and University info
    public string? UniEmail { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public ApplicationUser? User { get; set; }
    public int UniversityId { get; set; }
    [ForeignKey("UniversityId")]
    [ValidateNever]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public University? University { get; set; }

    public int FacultyId { get; set; }
    [ForeignKey("FacultyId")]
    [ValidateNever]
    public Faculty? Faculty { get; set; }

    public int MajorId { get; set; }
    [ForeignKey("MajorId")]
    [ValidateNever]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Major? Major { get; set; }

}