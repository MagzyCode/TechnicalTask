using Microsoft.AspNetCore.Identity;
using ServerPart.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public class RolesRepository : BaseRepository<IdentityRole>, IRolesRepository
    {
        public Task<IEnumerable<string>> GetRoles()
        {
            throw new NotImplementedException();
        }
    }
}
