using ServerPart.Contracts.RepositoryContracts;

namespace ServerPart.Contracts.RepositoryManagerContracts
{
    public interface IRepositoryManager
    {
        IFridgeModelRepository FridgeModel { get; }
        IFridgeProductsRepository FridgeProducts { get; }
        IFridgeRepository Fridge { get; }
        IProductsRepository Products { get; }
        void Save();
    }
}
