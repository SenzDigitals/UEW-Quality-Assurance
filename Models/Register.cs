
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UEW_Quality_Assurance.Models
{
    public class Register
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Username")]
        public string UserID { set; get; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public string ConfirmPassword { set; get; }

        [Display(Name ="Select User Role")]
        public string Role { set; get; }

       
    }
}

public enum Role
{
    Super_Admin,
    Admin
    //Guest

}