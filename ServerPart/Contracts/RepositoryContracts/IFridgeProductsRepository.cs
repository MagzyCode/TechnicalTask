using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeProductsRepository
    {
        public Task CallStoredProcedureAsync();
        public Guid AddProductInFridge(FridgeProducts fridgeProduct);
        public Task<FridgeProducts> GetFridgeProductAsync(Guid id);
        public Task<IEnumerable<FridgeProducts>> GetAllFridgesProductsAsync();
        public void DeleteFridgeProduct(FridgeProducts fridgeProduct);
        public void UpdateFridgeProduct(FridgeProducts updatedFridgeProduct);
        public Task<FridgeProducts> GetFridgeProductByGuidsAsync(Guid fridgeId, Guid productId);
    }
}
