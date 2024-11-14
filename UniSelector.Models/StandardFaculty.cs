using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace UniSelector.Models
{
    public class StandardFaculty
    {
        public int Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string CombinedName => $"{NameArabic} / {NameEnglish}";

        // One-to-many with StandardMajors
        public ICollection<StandardMajor> StandardMajors { get; set; } = new List<StandardMajor>();
    }
}
