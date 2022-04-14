using ServerPart.Models.DTOs;
using Swashbuckle.Examples;

namespace ServerPart.Models.Documentation.Swagger
{
    public class RegisterUserExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserForRegistrationDto()
            {
                FirstName = "Andrei",
                LastName = "Kazarevich",
                UserName = "Andre",
                Password = "slojnoNoMojno1045",
                Email = "andreikazarevich@mail.ru",
                PhoneNumber = "+375291986245",
                Roles = new[]
                {
                    "Administrator",
                    "Client"
                }
            };
        }
    }
}
