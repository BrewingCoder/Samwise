using System.Collections.Generic;
using System.Linq;

namespace Samwise.DataServices
{
    public interface IRepository
    {
        public interface IRepositoryLong<T> where T : IEntity
        {
            IEnumerable<T> GetAll();
            IQueryable<T> Query();
            void Create(T entity);
            void Update(T entity);
            void Delete(T entity);
            void Delete(long id);
            T Get(long id);
        }        
    }
}