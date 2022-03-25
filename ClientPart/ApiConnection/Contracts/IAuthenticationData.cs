using ClientPart.Models;
using Refit;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IAuthenticationData : IApiData
    {
        [Post("/api/authentication")]
        public Task RegisterUser([Body] User userForRegistration);

        [Post("/api/authentication/login")]
        public Task<string> Authenticate([Body] AuthenticationUser user);
    }
}
