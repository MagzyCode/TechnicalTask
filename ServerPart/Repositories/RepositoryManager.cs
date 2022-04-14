using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Contracts.RepositoryManagerContracts;

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

        public RepositoryManager(
            TaskContext context,
            IFridgeProductsRepository fridgeProductsRepository,
            IFridgeRepository fridgeRepository,
            IProductsRepository productsRepository,
            IFridgeModelRepository fridgeModelRepository,
            IRolesRepository rolesRepository)
        {
            _taskContext = context;
            _fridgeProductsRepository = fridgeProductsRepository;
            _fridgeRepository = fridgeRepository;
            _productsRepository = productsRepository;
            _fridgeModelRepository = fridgeModelRepository;
            _rolesRepository = rolesRepository;
        }

        public IFridgeModelRepository FridgeModel
        {
            get => _fridgeModelRepository;
        }

        public IFridgeProductsRepository FridgeProducts
        {
            get => _fridgeProductsRepository;
        }

        public IFridgeRepository Fridge
        {
            get => _fridgeRepository;
        }

        public IProductsRepository Products
        {
            get => _productsRepository;
        }

        public IRolesRepository Roles
        {
            get => _rolesRepository;
        }
    }
}
