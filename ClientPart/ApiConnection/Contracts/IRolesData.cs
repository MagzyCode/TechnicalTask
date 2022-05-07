using ClientPart.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IRolesData : IApiData
    {
        [Get("/api/roles")]
        Task<IEnumerable<string>> GetRolesAsync();
    }
}
