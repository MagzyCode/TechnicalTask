using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IAuthenticationData : IApiData
    {
        [Post("/api/authentication")]
        public Task RegisterUser([Body] RegistrationUserViewModel userForRegistration);

        [Post("/api/authentication/login")]
        public Task<object> Authenticate([Body] AuthenticationUserViewModel user);
    }
}
