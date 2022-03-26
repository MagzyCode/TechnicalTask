using ClientPart.ApiConnection.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class RolesService : BaseRefitService<IRolesData>
    {
        public RolesService(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            AuthenticationService authenticationService)
            : base(configuration, httpContextAccessor, authenticationService)
        { }

        public async Task<IEnumerable<string>> GetRolesAsync() => await _data.GetRolesAsync();
    }
}
