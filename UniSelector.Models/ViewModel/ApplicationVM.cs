using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UniSelector.Models;
using System.ComponentModel.DataAnnotations;

public class ApplicationVM
{
    [ValidateNever]
    public Application Application { get; set; }
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
    
    [Required(ErrorMessage = "The Civil-Id File Is Required")]
    public IFormFile CivilIdFile { get; set; }
    [Required(ErrorMessage = "The Passport File Is Required")]
    public IFormFile PassportFile { get; set; }
    [Required(ErrorMessage = "The High School Certificate File Is Required")]
    public IFormFile HighSchoolCertificateFile { get; set; }
    
    [ValidateNever]
    public bool MeetsTypeRequirement { get; set; }
    [ValidateNever]
    public bool MeetsGradeRequirement { get; set; }
    [ValidateNever]
    public bool MeetsLanguageRequirement { get; set; }
    public string? universityName { get; set; }
}