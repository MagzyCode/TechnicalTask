using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Models.DTOs
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "User first name is a required field.")]
        [StringLength(100, ErrorMessage = "Maximum lenght for the user first name is 100 characters.", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "User last name is a required field.")]
        [StringLength(100, ErrorMessage = "Maximum lenght for the user first name is 100 characters.", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "User name is a required field.")]
        [StringLength(40, ErrorMessage = "Maximum lenght for the user first name is 40 characters.", MinimumLength = 3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password is a required field.")]
        [StringLength(30, ErrorMessage = "Maximum lenght for the user first name is 30 characters.", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "User mail is a required field.")]
        [StringLength(60, ErrorMessage = "Maximum lenght for the user first name is 60 characters.", MinimumLength = 9)]
        public string Email { get; set; }
        [Required(ErrorMessage = "User mail is a required field.")]
        [StringLength(18, ErrorMessage = "Maximum lenght for the user first name is 18 characters.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
