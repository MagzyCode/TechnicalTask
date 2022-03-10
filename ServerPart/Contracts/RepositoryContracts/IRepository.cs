using ServerPart.Contracts.DbContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IRepository<T> where T:
        class, IDbModel
    {
        public void Create(T model);
        public void Update(T model);
        public void Delete(T model);
        public IQueryable<T> FindAll();
        public T GetModel(Guid id);
    }
}
