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

        public async Task<IEnumerable<FridgeModel>> GetFridgeModels(string token) => await _data.GetFridgeModels(token);
        public async Task<FridgeModel> GetFridgeModel(Guid fridgeModelId, string token) => await _data.GetFridgeModel(fridgeModelId, token);
    }
}
