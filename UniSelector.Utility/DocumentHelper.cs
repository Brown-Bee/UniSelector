using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using UniSelector.Utility;

public static class DocumentHelper
{
    public static string UploadDocument(IFormFile file, string documentType, IWebHostEnvironment webHostEnvironment)
    {
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string documentPath = Path.Combine(webHostEnvironment.WebRootPath, SD.ApplicationDocumentsPath.TrimStart('\\'));

        if (!Directory.Exists(documentPath))
            Directory.CreateDirectory(documentPath);

        using (var fileStream = new FileStream(Path.Combine(documentPath, fileName), FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return SD.ApplicationDocumentsPath + fileName;
    }

    public static bool DeleteDocument(string filePath, IWebHostEnvironment webHostEnvironment)
    {
        if (string.IsNullOrEmpty(filePath)) return false;

        string fullPath = Path.Combine(webHostEnvironment.WebRootPath, filePath.TrimStart('\\'));
        if (System.IO.File.Exists(fullPath))
        {
            System.IO.File.Delete(fullPath);
            return true;
        }
        return false;
    }
}