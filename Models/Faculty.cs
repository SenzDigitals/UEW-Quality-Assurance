using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Faculty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int facultyID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public int campusID { get; set; }

        public int departmentID { get; set; }

        public Campus Campus { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
