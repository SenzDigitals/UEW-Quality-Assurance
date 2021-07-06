using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Email
    {
        [Key]
        public string To { set; get; }
        public string Subject { get; set; }
        public string  Body { get; set; }


    }
}
