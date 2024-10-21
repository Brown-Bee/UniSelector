using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniSelector.Models.ViewModel
{
    public class FacultyVM
    {
        public Faculty faculty { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> facultyList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> UniversityList { get; set; }

    }
}