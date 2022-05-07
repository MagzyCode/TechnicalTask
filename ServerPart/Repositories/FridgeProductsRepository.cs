using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ServerPart.Repositories
{
    public class FridgeProductsRepository : BaseRepository<FridgeProducts>, IFridgeProductsRepository
    {
        public FridgeProductsRepository(TaskContext context) : base(context)
        { }

        public async Task CallStoredProcedureAsync()
        {
            await Context.Database.ExecuteSqlRawAsync("EXEC sp_TaskMethod");
            SaveChanges();
        }

        public Guid AddProductInFridge(FridgeProducts fridgeProduct)
        {
            if (fridgeProduct == null)
                return Guid.Empty;

            Create(fridgeProduct);
            SaveChanges();
            return fridgeProduct.Id;
        }

        public async Task<FridgeProducts> GetFridgeProductAsync(Guid id)
            => await GetAll().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<FridgeProducts>> GetAllFridgesProductsAsync() => await GetAll().ToListAsync();

        public void DeleteFridgeProduct(FridgeProducts fridgeProduct)
        {
            Delete(fridgeProduct);
            SaveChanges();
        }

        public void UpdateFridgeProduct(FridgeProducts updatedFridgeProduct)
        {
            Update(updatedFridgeProduct);
            SaveChanges();
        }

        public async Task<FridgeProducts> GetFridgeProductByGuidsAsync(Guid fridgeId, Guid productId)
        {
            var fridgeProducts = await GetAllFridgesProductsAsync();

            return fridgeProducts.FirstOrDefault(x => x.FridgeId == fridgeId && x.ProductId == productId);
        }
    }
}
