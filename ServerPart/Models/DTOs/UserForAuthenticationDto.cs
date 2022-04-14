using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models.DTOs
{
    public class UserForAuthenticationDto
    {
        /// <summary>
        /// Represents name of user in system, which using for authentication.
        /// </summary>
        /// <example>
        /// MagzyCode
        /// </example>
        [Required(ErrorMessage = "User name field is required.")]
        public string UserName { get; set; }

        /// <summary>
        /// Represents password of user in system, which using for authentication.
        /// </summary>
        /// <example>
        /// slojnoNoMojno1045
        /// </example>
        [Required(ErrorMessage = "User password field is required.")]
        public string Password { get; set; }
    }
}
