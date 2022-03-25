using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeProductsService : BaseRefitService<IFridgeProductsData>
    {
        public FridgeProductsService(IConfiguration configuration) : base(configuration)
        { }

        public async Task CallServerProcedureAsync() => await _data.CallServerProcedureAsync();

        public async Task<FridgeProducts> GetFridgeProductByIdAsync(Guid fridgeProductId, string token) 
            => await _data.GetFridgeProductByIdAsync(fridgeProductId, token);

        public async Task AddFridgeProductAsync(FridgeProducts creationFridgeProduct, string token) 
            => await _data.AddFridgeProductAsync(creationFridgeProduct, token);

        public async Task DeleteFridgeProductAsync(Guid fridgeProductId, string token) 
            => await _data.DeleteFridgeProductAsync(fridgeProductId, token);

        public async Task<IEnumerable<FridgeProducts>> GetFridgesProductsAsync(string token) 
            => await _data.GetFridgesProductsAsync(token);

    }
}
