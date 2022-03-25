using ClientPart.ApiConnection.Contracts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class RolesService : BaseRefitService<IRolesData>
    {
        public RolesService(IConfiguration configuration) : base(configuration)
        { }

        public async Task<IEnumerable<string>> GetRolesAsync() => await _data.GetRolesAsync();
    }
}
