using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniSelector.Models.ViewModel;

public class MajorVM
{
    public Major Major { get; set; }
    public List<SelectListItem>? StandardFaculties { get; set; }
}