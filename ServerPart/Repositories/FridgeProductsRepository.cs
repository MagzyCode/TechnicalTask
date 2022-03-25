using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public class FridgeProductsRepository : BaseRepository<FridgeProducts>, IFridgeProductsRepository
    {
        public FridgeProductsRepository(TaskContext context) : base(context)
        { }

        public async Task CallStoredProcedureAsync()
        {
             await Context.Database.ExecuteSqlRawAsync("EXEC sp_TaskMethod");
        }

        public Guid AddProductInFridge(FridgeProducts fridgeProduct)
        {
            if (fridgeProduct == null)
                return Guid.Empty;

            Create(fridgeProduct);
            return fridgeProduct.Id;
        }

        public async Task<FridgeProducts> GetFridgeProductAsync(Guid id) 
            => await FindAll()
                .Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<FridgeProducts>> GetAllFridgesProductsAsync() => await FindAll().ToListAsync();

        public void DeleteFridgeProduct(FridgeProducts fridgeProduct) => Delete(fridgeProduct);

        public void UpdateFridgeProduct(FridgeProducts updatedFridgeProduct) => Update(updatedFridgeProduct);
    }
}
