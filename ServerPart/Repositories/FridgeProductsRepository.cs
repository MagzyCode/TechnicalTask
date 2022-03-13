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
            var appendedFridgeProducts = Context.FridgeProducts
                .Where(x => x.FridgeId == fridgeProduct.FridgeId && x.ProductId == fridgeProduct.ProductId);
            FridgeProducts appendedFridgeProduct = appendedFridgeProducts.Any() ? appendedFridgeProducts.First() : null;
            if (appendedFridgeProduct == null)
            {
                Create(fridgeProduct);
                return fridgeProduct.Id;
            }
            else
            {
                appendedFridgeProduct.Quantity += fridgeProduct.Quantity;
                Update(appendedFridgeProduct);
                return appendedFridgeProduct.Id;
            }                
        }

        // TODO: Проверить, работает ли функция в таком исполнение, а если нет, то поменять на как в книге на метод FindByCondition(Func<T>);
        public Task<FridgeProducts> GetFridgeProductAsync(Guid id) => FindAll().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        public async Task<IEnumerable<FridgeProducts>> GetAllFridgesProductsAsync() => await FindAll().ToListAsync();

        public void DeleteFridgeProduct(FridgeProducts fridgeProduct) => Delete(fridgeProduct);
    }
}
