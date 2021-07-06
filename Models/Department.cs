using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int departmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int facultyID { get; set; }

        public Faculty faculty { get; set; }

        public IEnumerable<Prog> Program { get; set; }
    }
}
