using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IFridgeRepository
    {
        public IEnumerable<Products> GetFridgeProducts(Guid fridgeGuid);

        public IEnumerable<Fridge> GetAllFridges();

        public Fridge GetFridge(Guid id);
    }
}
