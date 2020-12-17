using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Enumerations;

namespace University.BL.Models
{
    [Table("Enrollment", Schema = "dbo")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        //[ForeignKey("Course")]
        public int CourseID { get; set; }

        //[ForeignKey("Student")]
        public int StudentID { get; set; }

        public EGrade Grade { get; set; }

        public Student student { get; set; }

        public Course course { get; set; }
    }
}
