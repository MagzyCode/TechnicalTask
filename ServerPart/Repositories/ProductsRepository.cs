using Microsoft.EntityFrameworkCore;
using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(TaskContext context) : base(context)
        { }

        public Task<Products> GetProductAsync(Guid id) => FindAll().Where(x => x.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task<IEnumerable<Products>> GetProductsAsync() => await FindAll().ToListAsync();
    }
}
