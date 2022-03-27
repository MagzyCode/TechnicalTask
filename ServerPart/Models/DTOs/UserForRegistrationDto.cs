using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerPart.Models.DTOs
{
    public class UserForRegistrationDto
    {
        /// <summary>
        /// Represents first name of new user.
        /// </summary>
        /// <example>
        /// Mikhail
        /// </example>
        [Required(ErrorMessage = "User first name is a required field.")]
        [StringLength(100, ErrorMessage = "Maximum lenght for the user first name is 100 characters.", MinimumLength = 2)]
        public string FirstName { get; set; }

        /// <summary>
        /// Represents last name of new user.
        /// </summary>
        /// <example>
        /// Kazarevich
        /// </example>
        [Required(ErrorMessage = "User last name is a required field.")]
        [StringLength(100, ErrorMessage = "Maximum lenght for the user first name is 100 characters.", MinimumLength = 2)]
        public string LastName { get; set; }

        /// <summary>
        /// Represents user name of new user.
        /// </summary>
        /// <example>
        /// MagzyCode
        /// </example>
        [Required(ErrorMessage = "User name is a required field.")]
        [StringLength(40, ErrorMessage = "Maximum lenght for the user first name is 40 characters.", MinimumLength = 3)]
        public string UserName { get; set; }

        /// <summary>
        /// Represents password of new user.
        /// </summary>
        /// <example>
        /// slojnoNoMojno1045
        /// </example>
        [Required(ErrorMessage = "User password is a required field.")]
        [StringLength(30, ErrorMessage = "Maximum lenght for the user first name is 30 characters.", MinimumLength = 5)]
        public string Password { get; set; }

        /// <summary>
        /// Represents email of new user.
        /// </summary>
        /// <example>
        /// mihailkazarevich@mail.ru
        /// </example>
        [Required(ErrorMessage = "User mail is a required field.")]
        [StringLength(60, ErrorMessage = "Maximum lenght for the user first name is 60 characters.", MinimumLength = 9)]
        public string Email { get; set; }

        /// <summary>
        /// Represents phone number of new user.
        /// </summary>
        /// <example>
        /// +375297058123
        /// </example>
        [Required(ErrorMessage = "User mail is a required field.")]
        [StringLength(18, ErrorMessage = "Maximum lenght for the user first name is 18 characters.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Represents role of new user in system.
        /// </summary>
        /// <example>
        /// ["Administrator", "Client"]
        /// </example>
        [Required(ErrorMessage = "Every user should have some role. Select one.")]
        public ICollection<string> Roles { get; set; }
    }
}
