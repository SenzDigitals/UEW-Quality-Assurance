using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string courseID { get; set; }

        public string title { get; set; }

        public int departmentID { get; set; }

        public Department Department  { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

        public IEnumerable<Lecturer> Lecturer { get; set;}            

    }
}
