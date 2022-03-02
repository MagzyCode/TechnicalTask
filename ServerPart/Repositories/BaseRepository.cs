﻿using ServerPart.Context;
using ServerPart.Contracts.DbContracts;
using ServerPart.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Repositories
{
    public abstract class BaseRepository<T> 
        : IRepository<T> where T : class, IDbModel
    {
        private protected TaskContext _taskContext;

        public BaseRepository(TaskContext context)
        {
            Context = context;
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

        public void Create(T model)
        {
            Context.Set<T>().Add(model);
        }

        public void Delete(T model)
        {
            Context.Set<T>().Remove(model);
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>();
        }

        public T GetModel(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T model)
        {
            Context.Set<T>().Update(model);
        }
    }
}
