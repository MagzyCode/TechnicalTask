using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeRepository : IRepository<Fridge>
    {
        public IQueryable<Products> GetFridgeProducts(Guid fridgeGuid);
        public void ClearFridge(Guid fridgeGuid);
    }
}
