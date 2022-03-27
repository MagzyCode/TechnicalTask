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
            // try this, but on my side that don't work
            var procedure =
                "IF OBJECT_ID('sp_TaskMethod', 'P') IS NOT NULL\n" +
                "   DROP PROCEDURE sp_TaskMethod;\n" +
                "GO\n" +
                "CREATE PROCEDURE sp_TaskMethod\n" +
                "AS\n" +
                "BEGIN\n" +
                "   UPDATE FridgeProducts\n" +
                "   SET Quantity = (SELECT DefaultQuantity FROM Products\n" +
                "      WHERE Products.Id = FridgeProducts.ProductId)\n" +
                "	WHERE Quantity = 0\n" +
                "END\n" +
                "GO\n" +
                "EXEC sp_TaskMethod";

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
