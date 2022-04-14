using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.Contracts.RepositoryContracts
{
    public interface IRepository<T>
    {
        public void Create(T model);
        public void Update(T model);
        public void Delete(T model);
        public IQueryable<T> GetAll();
        public T GetModel(Guid id);
        public void SaveChanges();
    }
}
