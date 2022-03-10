using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IProductsRepository
    {
        public Task<Products> GetProductAsync(Guid id);

        public Task<IEnumerable<Products>> GetProductsAsync();
    }
}
