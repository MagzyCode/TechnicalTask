using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeRepository
    {
        public Task<IEnumerable<Products>> GetFridgeProductsAsync(Guid fridgeGuid);

        public Task<IEnumerable<Fridge>> GetAllFridgesAsync();

        public Task<Fridge> GetFridgeAsync(Guid id);

        public void DeleteFridge(Fridge id);

        public Guid AddFridge(Fridge fridge);

        public void UpdateFridge(Fridge fridge);
    }
}
