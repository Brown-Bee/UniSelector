using Microsoft.AspNetCore.Http;

public class ApplicationVM
{
    public Application? Application { get; set; }

    // For file uploads only
    public IFormFile? CivilIdFile { get; set; }
    public IFormFile? PassportFile { get; set; }
    public IFormFile? HighSchoolCertificateFile { get; set; }

    // For profile fields that need to be updated
    public string? Name { get; set; }
    public string? CivilID { get; set; }
    public string? Gender { get; set; }
    public string? Nationality { get; set; }
    public string? MothersNationality { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PlaceOfBirth { get; set; }
    public string? Address { get; set; }
    public string? HighSchoolType { get; set; }
    public float? Grade { get; set; }
    public int? HighSchoolGraduationYear { get; set; }
    public float? IELTS { get; set; }
    public float? TOEFL { get; set; }
    public bool HasAptitudeTest { get; set; }

    // For requirement validation
    public bool MeetsTypeRequirement { get; set; }
    public bool MeetsGradeRequirement { get; set; }
    public bool MeetsLanguageRequirement { get; set; }
    public string[]? ValidationWarnings { get; set; }
}