using ClientPart.ApiConnection.Contracts;
using ClientPart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Services
{
    public class FridgeModelService : BaseRefitService<IFridgeModelData>
    {
        public FridgeModelService(
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            AuthenticationService authenticationService) 
            : base(configuration, httpContextAccessor, authenticationService)
        { }

        public async Task<IEnumerable<FridgeModel>> GetFridgeModelsAsync() => await _data.GetFridgeModelsAsync();
        public async Task<FridgeModel> GetFridgeModelAsync(Guid fridgeModelId) => await _data.GetFridgeModelAsync(fridgeModelId);
    }
}
