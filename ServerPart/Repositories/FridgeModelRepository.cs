using Microsoft.EntityFrameworkCore;
using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public class FridgeModelRepository : BaseRepository<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(TaskContext context) : base(context)
        { }

        public async Task<IEnumerable<FridgeModel>> GetAllFridgeModelsAsync() => await GetAll().ToListAsync();

        public async Task<FridgeModel> GetFridgeModelAsync(Guid id)
            => await GetAll()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
    }
}
