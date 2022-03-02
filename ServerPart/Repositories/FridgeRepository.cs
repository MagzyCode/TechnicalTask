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

        public void ClearFridge(Guid fridgeGuid)
        {
            var removingProducts = Context.FridgeProducts
                .Where(x => x.FridgeId == fridgeGuid);
            Context.FridgeProducts.RemoveRange(removingProducts);
        }

        public IQueryable<Products> GetFridgeProducts(Guid fridgeGuid)
        {
            var products = Context.Products;
            var result = Context.FridgeProducts
                .Where(x => x.FridgeId == fridgeGuid)
                .Select(x => products.First(i => i.Id == x.ProductId));
            return result;
        }
    }
}
