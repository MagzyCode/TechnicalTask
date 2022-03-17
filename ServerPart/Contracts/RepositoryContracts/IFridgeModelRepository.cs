using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeModelRepository
    {
        public Task<IEnumerable<FridgeModel>> GetAllFridgeModelsAsync();

        public Task<FridgeModel> GetFridgeModelAsync(Guid id);
    }
}
