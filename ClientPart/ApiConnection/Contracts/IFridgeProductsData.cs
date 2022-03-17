using ClientPart.Models;
using ClientPart.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPart.ApiConnection.Contracts
{
    public interface IFridgeProductsData : IApiData
    {
        [Get("/api/fridgeProducts/procedure")]
        public Task<IEnumerable<FridgeProductsViewModel>> CallServerProcedure();

        [Get("/api/fridgeProducts/{fridgeProductId}")]
        public Task<FridgeProductsViewModel> GetFridgeProductById(Guid fridgeProductId);

        [Post("/api/fridgeProducts")]
        public Task AddFridgeProduct([Body] CreationFridgeProductViewModel creationFridgeProduct);

        [Delete("/api/fridgeProducts/{fridgeProductId}")]
        public Task DeleteFridgeProduct(Guid fridgeProductId);
    }
}
