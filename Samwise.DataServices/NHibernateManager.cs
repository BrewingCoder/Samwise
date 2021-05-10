using System;
using System.Diagnostics.CodeAnalysis;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using YesSql;

namespace Samwise.DataServices
{
    /// <summary>
    /// Singleton provider of session factory
    /// Excluded from testing, for now at least
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class NHibernateManager
    {
        private static Lazy<ISessionFactory> _sSessionFactoryLazy;

        public static ISessionFactory Instance(IStore store,string connectionString)
        {
            if (_sSessionFactoryLazy is {IsValueCreated: true}) return _sSessionFactoryLazy.Value;
            _sSessionFactoryLazy = new Lazy<ISessionFactory>(CreateSessionFactory(store,connectionString));
            return _sSessionFactoryLazy.Value;
        }
        
        private static ISessionFactory CreateSessionFactory(IStore store,string connectionString)
        {
            IPersistenceConfigurer configurer = store.Configuration.SqlDialect.Name switch
            {
                "Sqlite" => SQLiteConfiguration.Standard.ConnectionString(connectionString),
                "MySql" => MySQLConfiguration.Standard.ConnectionString(connectionString),
                "Postgres" => PostgreSQLConfiguration.Standard.ConnectionString(connectionString),
                "Sql" => MsSqlCeConfiguration.Standard.ConnectionString(connectionString),
                _ => null
            };

            return Fluently.Configure()
                .Database(configurer)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IEntity>())
                    
                .BuildSessionFactory();
        }
    }
}