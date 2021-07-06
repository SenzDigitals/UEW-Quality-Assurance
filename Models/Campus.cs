using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Campus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int campusID { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string campusName { get; set; }

        public string location { get; set; }

        public IEnumerable<Faculty> Faculties { get; set; }

    }
}
