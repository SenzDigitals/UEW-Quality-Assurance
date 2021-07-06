using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string studentID { get; set; }

        public string lname { get; set; }
        public string fname { get; set; }
        
        public int programID { get; set; }

        public IEnumerable<Enrollment> Enrollment { get; set; }

        public Prog Program { get; set; }

        public string fullName() { return lname + " " + fname; }
    }
}
