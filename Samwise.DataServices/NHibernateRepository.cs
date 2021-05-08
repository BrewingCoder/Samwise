using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace Samwise.DataServices
{
    public class NHibernateRepository<T> : IRepository where T: class, IEntity
    {
            private readonly IUnitOfWork _unitOfWork;
            private ISession Session => _unitOfWork.GetSession();

            public NHibernateRepository(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public IEnumerable<T> GetAll()
            {
                return Session.Query<T>().ToList();
            }
            public IQueryable<T> Query()
            {
                return Session.Query<T>();
            }
            public void Create(T entity)
            {
                Session.Save(entity);
            }
            public void Update(T entity)
            {
                Session.Update(entity);
            }
            public void Delete(T entity)
            {
                Session.Delete(entity);
            }
            public void Delete(long id)
            {
                var entity = Session.Get<T>(id);
                Session.Delete(entity);
            }
            public T Get(long id)
            {
                return Session.Get<T>(id);
            }
        }        
}