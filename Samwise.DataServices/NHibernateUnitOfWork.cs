using System;
using NHibernate;
using OrchardCore.Data;
using YesSql;
using ISession = NHibernate.ISession;

namespace Samwise.DataServices
{
    public class NHibernateUnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateUnitOfWork(IStore store, IDbConnectionAccessor accessor)
        {
            var conn = accessor.CreateConnection();
            _session = NHibernateManager.Instance(store,conn.ConnectionString)
                            .WithOptions()
                            .Connection(accessor.CreateConnection())
                            .OpenSession();
            conn.Close();
        }

        ~NHibernateUnitOfWork()
        {
            Dispose(false);
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

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing)
            {
                _session?.Dispose();
                _transaction?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}