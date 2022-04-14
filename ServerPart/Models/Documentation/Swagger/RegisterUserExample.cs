using ServerPart.Models.DTOs;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.Examples;
using System.Collections.Generic;

namespace ServerPart.Models.Documentation.Swagger
{
    public class RegisterUserExample : IMultipleExamplesProvider<UserForRegistrationDto>
    {
        public IEnumerable<SwaggerExample<UserForRegistrationDto>> GetExamples()
        {
            return new[]
            {
                new SwaggerExample<UserForRegistrationDto>()
                {
                    Value = new UserForRegistrationDto()
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
                    }
                }
            };
        }
    }
}
