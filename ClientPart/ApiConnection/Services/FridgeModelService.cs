using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeModelService : BaseRefitService<IFridgeModelData>
    {
        public FridgeModelService(IConfiguration configuration) : base(configuration)
        { }

        public async Task<IEnumerable<FridgeModel>> GetFridgeModelsAsync(string token) => await _data.GetFridgeModelsAsync(token);
        public async Task<FridgeModel> GetFridgeModelAsync(Guid fridgeModelId, string token) => await _data.GetFridgeModelAsync(fridgeModelId, token);
    }
}
