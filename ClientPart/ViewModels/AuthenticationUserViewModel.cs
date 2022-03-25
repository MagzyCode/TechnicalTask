using System.ComponentModel.DataAnnotations;

namespace ClientPart.ViewModels
{
    public class AuthenticationUserViewModel
    {
        [Required(ErrorMessage = "User name field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password field is required")]
        public string Password { get; set; }
    }
}
