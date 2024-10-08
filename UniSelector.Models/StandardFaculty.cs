﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSelector.Models
{
    public class StandardFaculty
    {
        public int Id { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string CombinedName => $"{NameArabic} / {NameEnglish}";

    }
}
