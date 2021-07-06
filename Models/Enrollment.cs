using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enrollmentID { get; set; }

        public string courseID { get; set; }

        public string  studentID { get; set; }

        public Course Course { get; set; }

    }
}
