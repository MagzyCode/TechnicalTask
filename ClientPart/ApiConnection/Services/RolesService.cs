using ClientPart.ApiConnection.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class RolesService : BaseRefitService<IRolesData>
    {
        public async Task<IEnumerable<string>> GetRolesAsync() => await _data.GetRolesAsync();
    }
}
