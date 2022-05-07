using Microsoft.AspNetCore.Identity;
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
    public class RolesRepository : IRolesRepository
    {
        private protected TaskContext _taskContext;
        private readonly UserManager<User> _userManager;

        public RolesRepository(TaskContext context, UserManager<User> userManager)
        {
            Context = context;
            _userManager = userManager;
        }

        public TaskContext Context
        {
            get
            {
                return _taskContext;
            }
            private set
            {
                _taskContext = value ?? throw new Exception("Context should be initialize");
            }
        }

        public async Task<IEnumerable<string>> GetRolesAsync()
            => await _taskContext.Roles
                    .Select(x => x.Name)
                    .ToListAsync();


    }
}
