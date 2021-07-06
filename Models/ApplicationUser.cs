using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class ApplicationUser : IdentityUser
    {
        

        [Display(Name ="Select User Role")]
        public string Role { set; get; }
    }
}
