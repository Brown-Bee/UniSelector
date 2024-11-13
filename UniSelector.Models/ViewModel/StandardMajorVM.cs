using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSelector.Models.ViewModel
{
    public class StandardMajorVM
    {
        public StandardMajor StandardMajor { get; set; }
        public IEnumerable<SelectListItem>? StandardFacultyList { get; set; }
    }
}