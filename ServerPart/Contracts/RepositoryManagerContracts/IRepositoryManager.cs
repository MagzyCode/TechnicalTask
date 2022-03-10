using ServerPart.Contracts.RepositoryContracts;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryManagerContracts
{
    public interface IRepositoryManager
    {
        IFridgeModelRepository FridgeModel { get; }
        IFridgeProductsRepository FridgeProducts { get; }
        IFridgeRepository Fridge { get; }
        IProductsRepository Products { get; }
        Task SaveAsync();
    }
}
