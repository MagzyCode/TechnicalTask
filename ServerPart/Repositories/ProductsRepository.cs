﻿using ServerPart.Context;
using ServerPart.Contracts.RepositoryContracts;
using ServerPart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerPart.Repositories
{
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(TaskContext context) : base(context)
        { }

        public Products GetProduct(Guid id) => GetModel(id);

        public IEnumerable<Products> GetProducts() => FindAll().ToList();
    }
}
