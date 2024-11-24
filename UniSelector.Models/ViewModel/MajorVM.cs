using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniSelector.Models.ViewModel;

public class MajorVM
{
    public Major Major { get; set; }
    public List<SelectListItem>? StandardFaculties { get; set; }
    public List<SelectListItem>? StandardMajors { get; set; }
    
    public List<Major>? Majors { get; set; }
    public string? FacultyName { get; set; }
    public int StandardFacultyId { get; set; }
    public int UniId { get; set; }
}