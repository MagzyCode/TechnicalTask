using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class AuthenticationService : BaseRefitService<IAuthenticationData>
    {
        public AuthenticationService(IConfiguration configuration) : base (configuration)
        { }

        public async Task RegisterUserAsync(User model) => await _data.RegisterUserAsync(model);

        public async Task<string> AuthenticateAsync(AuthenticationUser model) => await _data.AuthenticateAsync(model);

        public string GetToken(Controller controller)
        {
            var tokenClaim = controller.HttpContext?.User?.Claims?.First(x => x.Type.Equals("Token"));

            if (tokenClaim != null)
                return tokenClaim.Value;

            return string.Empty;
        }
    }
}
