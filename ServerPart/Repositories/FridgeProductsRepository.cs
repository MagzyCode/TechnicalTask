using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ServerPart.Repositories
{
    public class FridgeProductsRepository : BaseRepository<FridgeProducts>, IFridgeProductsRepository
    {
        public FridgeProductsRepository(TaskContext context) : base(context)
        { }

        public void CallStoredProcedure()
        {
            Context.Database.ExecuteSqlRaw("EXEC sp_TaskMethod");
        }

        public Guid AddProductInFridge(FridgeProducts fridgeProduct)
        {
            var appendedFridgeProducts = Context.FridgeProducts
                .Where(x => x.FridgeId == fridgeProduct.FridgeId && x.ProductId == fridgeProduct.ProductId);
            FridgeProducts appendedFridgeProduct = appendedFridgeProducts.Any() ? appendedFridgeProducts.First() : null;
            if (appendedFridgeProduct == null)
            {
                Create(fridgeProduct);
                return fridgeProduct.Id;
            }
            else
            {
                appendedFridgeProduct.Quantity += fridgeProduct.Quantity;
                Update(appendedFridgeProduct);
                return appendedFridgeProduct.Id;
            }                
        }

        public FridgeProducts GetFridgeProduct(Guid id) => GetModel(id);

        public IEnumerable<FridgeProducts> GetAllFridgesProducts() => FindAll().ToList();

        public void DeleteFridgeProduct(FridgeProducts fridgeProduct) => Delete(fridgeProduct);
    }
}
