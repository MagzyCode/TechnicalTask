using ClientPart.Models;
using Refit;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IAuthenticationData : IApiData
    {
        [Post("/api/registration")]
        public Task RegisterUserAsync([Body] User userForRegistration);

        [Post("/api/authentication/login")]
        public Task<string> AuthenticateAsync([Body] AuthenticationUser user);

        [Post("/api/user/role")]
        Task<string> GetUserRoleAsync(AuthenticationUser user);
    }
}
