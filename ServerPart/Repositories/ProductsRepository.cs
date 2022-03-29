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

        public async Task<Products> GetProductAsync(Guid id)
            => await GetAll().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Products>> GetProductsAsync() => await GetAll().ToListAsync();
    }
}
