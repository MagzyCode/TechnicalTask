using Microsoft.AspNetCore.Identity;

namespace ServerPart.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
