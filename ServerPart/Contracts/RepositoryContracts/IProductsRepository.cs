using ServerPart.Models;
using System;
using System.Collections.Generic;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IProductsRepository
    {
        public Products GetProduct(Guid id);

        public IEnumerable<Products> GetProducts();
    }
}
