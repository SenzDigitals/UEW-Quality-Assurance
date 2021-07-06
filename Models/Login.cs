using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UEW_Quality_Assurance.Data;

namespace UEW_Quality_Assurance.Models
{
    public class Login
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string loginID { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string password { set; get; }

        public bool RememberMe { get; set; }
    }
}
