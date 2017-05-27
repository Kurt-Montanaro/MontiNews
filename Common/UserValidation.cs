using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserValidation
    {
        [Required(ErrorMessage = "Input username")]
        public string Username { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password must be greater than 6 characters")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
            ErrorMessage = "Incorrect email")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
