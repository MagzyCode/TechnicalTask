using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeProductsService : BaseRefitService<IFridgeProductsData>
    {
        public FridgeProductsService(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            AuthenticationService authenticationService)
            : base(configuration, httpContextAccessor, authenticationService)
        { }

        public async Task CallServerProcedureAsync() => await _data.CallServerProcedureAsync();

        public async Task<FridgeProducts> GetFridgeProductByIdAsync(Guid fridgeProductId)
            => await _data.GetFridgeProductByIdAsync(fridgeProductId);

        public async Task AddFridgeProductAsync(FridgeProducts creationFridgeProduct)
            => await _data.AddFridgeProductAsync(creationFridgeProduct);

        public async Task DeleteFridgeProductAsync(Guid fridgeProductId)
            => await _data.DeleteFridgeProductAsync(fridgeProductId);

        public async Task<IEnumerable<FridgeProducts>> GetFridgesProductsAsync()
            => await _data.GetFridgesProductsAsync();

        public async Task UpdateFridgeProductAsync(Guid fridgeProductId, FridgeProducts updateFridgeProduct)
            => await _data.UpdateFridgeProductAsync(fridgeProductId, updateFridgeProduct);
    }
}
