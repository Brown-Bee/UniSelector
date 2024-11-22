using Microsoft.AspNetCore.Http;

public class ApplicationVM
{
    public Application? Application { get; set; }

    // For file uploads only
    public IFormFile? CivilIdFile { get; set; }
    public IFormFile? PassportFile { get; set; }
    public IFormFile? HighSchoolCertificateFile { get; set; }
}