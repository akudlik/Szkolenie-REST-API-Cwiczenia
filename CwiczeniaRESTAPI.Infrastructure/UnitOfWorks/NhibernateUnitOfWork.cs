using System.Reflection;
using CwiczeniaRESTAPI.SeedWork;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CwiczeniaRESTAPI.Infrastructure.UnitOfWorks
{
    public class NHibernateUnitOfWork : ITransactionUnitOfWork
    {
        private readonly string _connectionString;

        private ISession _session;

        public NHibernateUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Get DB session
        /// </summary>
        public ISession Session
        {
            get
            {
                if (_session != null && _session.IsOpen)
                    return _session;
                
                var sessionFactory2 = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
                _session = sessionFactory2.OpenSession();

                return _session;
            }
        }


        public void Dispose()
        {
            _session?.Dispose();
        }

        public IUnitOfWork BeginTransaction() => new TransactionNHibernate(Session.BeginTransaction());
    }
}