using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.AspNetCore.Http;
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

        public async Task<string> GetUserRoleAsync(AuthenticationUser user) => await _data.GetUserRoleAsync(user);

        public string GetToken(HttpContext context)
        {
            var tokenClaim = context?.User?.Claims?.First(x => x.Type == "Token");

            if (tokenClaim != null)
                return tokenClaim.Value;

            return string.Empty;
        }
    }
}
