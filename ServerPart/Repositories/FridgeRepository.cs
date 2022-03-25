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
    public class FridgeRepository : BaseRepository<Fridge>, IFridgeRepository
    {
        public FridgeRepository(TaskContext context) : base(context)
        { }

        public Guid AddFridge(Fridge fridge)
        {
            if (fridge == null)
                return Guid.Empty;

            Create(fridge);
            return fridge.Id;
        }

        public void DeleteFridge(Fridge fridge) => Delete(fridge);

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync() => await FindAll().ToListAsync();

        public async Task<Fridge> GetFridgeAsync(Guid id) => await FindAll().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task<IEnumerable<Products>> GetFridgeProductsAsync(Guid fridgeId)
        {
            var products = Context.Products;
            var result = await Context.FridgeProducts
                .Where(x => x.FridgeId == fridgeId)
                .Select(x => products.First(i => i.Id == x.ProductId))
                .ToListAsync();

            return result;
        }


    }
}
