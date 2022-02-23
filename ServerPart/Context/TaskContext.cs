using Microsoft.EntityFrameworkCore;
using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> GetFridgeModels { get; set; }
        public DbSet<FridgeProducts> FridgeProducts { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
