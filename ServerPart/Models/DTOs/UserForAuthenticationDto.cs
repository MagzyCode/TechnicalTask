using System.ComponentModel.DataAnnotations;

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
