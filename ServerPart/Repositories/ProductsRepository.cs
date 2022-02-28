using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;

namespace ServerPart.Repositories
{
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(TaskContext context) : base(context)
        { }
    }
}
