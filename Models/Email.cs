using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Email
    {
        [Key]
        public string To { set; get; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string  Body { get; set; }

    }
}
