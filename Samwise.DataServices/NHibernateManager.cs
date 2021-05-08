using System;
using FluentNHibernate.Cfg;
using NHibernate;

namespace Samwise.DataServices
{
    public static class NHibernateManager
    {
        private static Lazy<ISessionFactory> _sSessionFactoryLazy;

        public static ISessionFactory Instance()
        {
            if (_sSessionFactoryLazy is {IsValueCreated: true}) return _sSessionFactoryLazy.Value;
            _sSessionFactoryLazy = new Lazy<ISessionFactory>(CreateSessionFactory());
            return _sSessionFactoryLazy.Value;
        }
        
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IEntity>())
                .BuildSessionFactory();
        }
    }
}