using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class AuthenticationService : BaseRefitService<IAuthenticationData>
    {
        public async Task RegisterUser(User model) => await _data.RegisterUser(model);

        public async Task<string> Authenticate(AuthenticationUser model) => await _data.Authenticate(model);

        public string GetToken(Controller controller)
        {
            var tokenClaim = controller.HttpContext?.User?.Claims?.First(x => x.Type.Equals("Token"));

            if (tokenClaim != null)
                return tokenClaim.Value;

            return string.Empty;
        }
    }
}
