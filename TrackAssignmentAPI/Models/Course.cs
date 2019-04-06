using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAssignmentAPI.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string CourseNumber { get; set; }

        public int Section { get; set; }
    }
}
