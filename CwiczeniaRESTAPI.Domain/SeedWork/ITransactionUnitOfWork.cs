using System;

namespace CwiczeniaRESTAPI.SeedWork
{
    public interface ITransactionUnitOfWork : IDisposable
    {
        IUnitOfWork BeginTransaction();
    }
}