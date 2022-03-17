using ClientPart.ApiConnection.Contracts;
using ClientPart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class AuthenticationService : BaseRefitService<IAuthenticationData>
    {
        public async Task RegisterUser(RegistrationUserViewModel model) => await _data.RegisterUser(model);

        public async Task<string> Authenticate(AuthenticationUserViewModel model) => await _data.Authenticate(model);
    }
}
