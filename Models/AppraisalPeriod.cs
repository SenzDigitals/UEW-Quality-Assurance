using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class AppraisalPeriod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Academic Year")]
        public DateTime academicYear { set; get; }

        [Required]
        [Display(Name = "Semester")]
        public int semester { set; get; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime startDate { set; get; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        public DateTime endDate { set; get; }

        
    }
}
