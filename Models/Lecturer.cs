using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Lecturer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int lecturerID { get; set; }

        public string Lname { get; set; }

        public string Fname { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public int departmentID { get; set; }
              

        public Department Department { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
