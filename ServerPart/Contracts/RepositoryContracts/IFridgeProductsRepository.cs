using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
