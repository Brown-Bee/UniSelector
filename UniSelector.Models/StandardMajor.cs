using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSelector.Models
{
    public class StandardMajor
    {
        [Key]
        public int Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string CombinedName => $"{NameArabic} / {NameEnglish}";

        public int StandardFacultyId { get; set; }
        [ForeignKey("StandardFacultyId")]
        public StandardFaculty? StandardFaculty { get; set; }
    }
}