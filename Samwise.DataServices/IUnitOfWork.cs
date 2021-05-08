using NHibernate;

namespace Samwise.DataServices
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        ISession GetSession();
    }
}