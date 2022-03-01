using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ServerPart.Repositories
{
    public class FridgeProductsRepository : BaseRepository<FridgeProducts>, IFridgeProductsRepository
    {
        public FridgeProductsRepository(TaskContext context) : base(context)
        { }

        public void CallStoredProcedure()
        {
            Context.Database.ExecuteSqlRaw("EXEC sp_TaskMethod");
        }

        public void ClearFridge(Guid fridgeGuid)
        {
            var removingProducts = Context.Set<FridgeProducts>()
                .Where(x => x.FridgeId == fridgeGuid);
            Context.Set<FridgeProducts>().RemoveRange(removingProducts);
        }

        public IQueryable<Products> GetFridgeProducts(Guid fridgeGuid)
        {
            var products = Context.Set<Products>();
            var result = Context.Set<FridgeProducts>()
                .Where(x => x.FridgeId == fridgeGuid)
                .Select(x => products.First(i => i.Id == x.ProductId));
            return result;
        }
    }
}
