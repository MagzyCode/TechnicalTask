using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;

namespace ServerPart.Repositories
{
    public class FridgeModelRepository : BaseRepository<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(TaskContext context) : base(context)
        { }
    }
}
