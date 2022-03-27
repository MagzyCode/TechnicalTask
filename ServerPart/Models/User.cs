using Microsoft.AspNetCore.Identity;

namespace ServerPart.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// sdfsdf
        /// </summary>
        /// <example>
        /// Mikhail
        /// </example>
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
