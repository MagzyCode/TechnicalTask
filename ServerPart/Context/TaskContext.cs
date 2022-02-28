using Microsoft.EntityFrameworkCore;
using ServerPart.Models;
using ServerPart.Models.Configuration;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FridgeModelConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeProductsConfiguration());
        }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> GetFridgeModels { get; set; }
        public DbSet<FridgeProducts> FridgeProducts { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
