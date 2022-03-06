using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public class FridgeRepository : BaseRepository<Fridge>, IFridgeRepository
    {
        public FridgeRepository(TaskContext context) : base(context)
        { }

        public IEnumerable<Fridge> GetAllFridges() => FindAll().ToList();

        public Fridge GetFridge(Guid id) => GetModel(id);

        public IEnumerable<Products> GetFridgeProducts(Guid fridgeId)
        {
            var products = Context.Products;
            var result = Context.FridgeProducts
                .Where(x => x.FridgeId == fridgeId)
                .Select(x => products.First(i => i.Id == x.ProductId))
                .ToList();
            return result;
        }
    }
}
