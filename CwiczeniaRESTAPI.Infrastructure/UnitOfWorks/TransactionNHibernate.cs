using System;
using CwiczeniaRESTAPI.SeedWork;
using NHibernate;

namespace CwiczeniaRESTAPI.Infrastructure.UnitOfWorks
{
    public class TransactionNHibernate : IUnitOfWork
    {
        private readonly ITransaction _transaction;


        public TransactionNHibernate(ITransaction transaction)
        {
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollbackChanges()
        {
            _transaction.Rollback();
        }

    }
}