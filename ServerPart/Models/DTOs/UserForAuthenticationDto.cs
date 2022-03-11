using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models.DTOs
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password field is required")]
        public string Password { get; set; }
    }
}
