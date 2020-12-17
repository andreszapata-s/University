﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage = "El courseID es requerido")]
        public int CourseId { get; set; }

        [Required(ErrorMessage ="El titulo es requerido")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "El credito es requerido")]
        public int Credits { get; set; }
    }
}
