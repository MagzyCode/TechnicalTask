using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeProductsRepository
    {
        public void CallStoredProcedure();
        public Guid AddProductInFridge(FridgeProducts fridgeProduct);
        public FridgeProducts GetFridgeProduct(Guid id);
        public IEnumerable<FridgeProducts> GetAllFridgesProducts();
        public void DeleteFridgeProduct(FridgeProducts fridgeProduct);
    }
}
