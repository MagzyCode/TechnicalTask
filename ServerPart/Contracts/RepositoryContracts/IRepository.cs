using System;
using System.Linq;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IRepository<T>
    {
        public void Create(T model);
        public void Update(T model);
        public void Delete(T model);
        public IQueryable<T> FindAll();
        public T GetModel(Guid id);
    }
}
