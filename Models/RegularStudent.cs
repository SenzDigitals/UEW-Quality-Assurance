using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class RegularStudent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
        public Lecturer Lecturer { get; set; }
        public Double Results { get; set; }
    }
}
