using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Contracts.RepositoryManagerContracts;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly TaskContext _taskContext;
        private IFridgeProductsRepository _fridgeProductsRepository;
        private IFridgeRepository _fridgeRepository;
        private IProductsRepository _productsRepository;
        private IFridgeModelRepository _fridgeModelRepository;
        private IRolesRepository _rolesRepository;

        public RepositoryManager(TaskContext context)
        {
            _taskContext = context;
        }

        public IFridgeModelRepository FridgeModel
        {
            get
            {
                if (_fridgeModelRepository == null)
                    _fridgeModelRepository = new FridgeModelRepository(_taskContext);
                return _fridgeModelRepository;
            }
        }

        public IFridgeProductsRepository FridgeProducts
        {
            get
            {
                if (_fridgeProductsRepository == null)
                    _fridgeProductsRepository = new FridgeProductsRepository(_taskContext);
                return _fridgeProductsRepository;
            }
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                    _fridgeRepository = new FridgeRepository(_taskContext);
                return _fridgeRepository;
            }
        }

        public IProductsRepository Products
        {
            get
            {
                if (_productsRepository == null)
                    _productsRepository = new ProductsRepository(_taskContext);
                return _productsRepository;
            }
        }

        public IRolesRepository Roles
        {
            get
            {
                if (_rolesRepository == null)
                    _rolesRepository = new RolesRepository(_taskContext);
                return _rolesRepository;
            }
        }

        public async Task SaveAsync() => await _taskContext.SaveChangesAsync();
    }
}
