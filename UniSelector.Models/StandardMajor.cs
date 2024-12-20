﻿using System;
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

        public string? Description { get; set; }  // Career prospects, program details
        [Display(Name = "Study Duration (Years)")]
        public int StudyDuration { get; set; }
        [Display(Name = "High School Path")]
        public string HighSchoolPath { get; set; }  // Scientific/Literary/Both track

        public int StandardFacultyId { get; set; }
        [ForeignKey("StandardFacultyId")]
        public StandardFaculty? StandardFaculty { get; set; }
    }
}