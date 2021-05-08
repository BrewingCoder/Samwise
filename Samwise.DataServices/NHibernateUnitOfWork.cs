using NHibernate;
using OrchardCore.Data;

namespace Samwise.DataServices
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateUnitOfWork(IDbConnectionAccessor dbAccessor)
        {
            _session = NHibernateManager.Instance().WithOptions().Connection(dbAccessor.CreateConnection()).OpenSession();
        }

        ~NHibernateUnitOfWork()
        {
            _session?.Close();
        }

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            if(_transaction is {IsActive: true})
                _transaction.Commit();
        }

        public void Rollback()
        {
            if(_transaction is {IsActive: true})
                _transaction.Rollback();
        }

        public ISession GetSession()
        {
            return _session;
        }        
    }
}