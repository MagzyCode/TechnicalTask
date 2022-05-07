using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IRolesRepository
    {
        public Task<IEnumerable<string>> GetRolesAsync();
    }
}
