using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeProductsRepository : IRepository<FridgeProducts>
    {
        public void CallStoredProcedure();
        // public void ClearFridge(Guid fridgeGuid);
        // public IQueryable<Products> GetFridgeProducts(Guid fridgeGuid);
    }
}
