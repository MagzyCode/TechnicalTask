using ServerPart.Models.DTOs;
using System.Threading.Tasks;

namespace ServerPart.Contracts.AuthenticationManagerContracts
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        Task<string> GetUserRoleAsync(string userName);
    }
}
