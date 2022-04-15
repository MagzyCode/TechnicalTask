using ServerPart.Models.DTOs;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace ServerPart.Models.Documentation.Swagger
{
    public class RequestModel : IMultipleExamplesProvider<UserForRegistrationDto>
    {
        public IEnumerable<SwaggerExample<UserForRegistrationDto>> GetExamples()
        {
            return new[]
            {
                new SwaggerExample<UserForRegistrationDto>()
                {
                    Name = "User registration",
                    Summary = "Give user registration example",
                    Value = new UserForRegistrationDto()
                    {
                        FirstName = "Natalia",
                        LastName = "Kazarevich",
                        UserName = "Nata",
                        Password = "slojnoNoMojno1045",
                        Email = "natakazarevich@mail.ru",
                        PhoneNumber = "+375291734620",
                        Roles = new List<string>()
                        {
                            "Client"
                        }
                    }
                }
            };
        }
    }
}
