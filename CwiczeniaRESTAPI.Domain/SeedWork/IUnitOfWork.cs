using System;

namespace CwiczeniaRESTAPI.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void RollbackChanges();
    }
}