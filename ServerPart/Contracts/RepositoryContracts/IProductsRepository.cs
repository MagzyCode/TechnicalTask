using ServerPart.Models;
using System;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IProductsRepository
    {
        public Products GetProduct(Guid id);
    }
}
