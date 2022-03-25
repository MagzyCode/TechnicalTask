using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IRolesData : IApiData
    {
        [Get("/api/roles")]
        Task<IEnumerable<string>> GetRolesAsync();
    }
}
