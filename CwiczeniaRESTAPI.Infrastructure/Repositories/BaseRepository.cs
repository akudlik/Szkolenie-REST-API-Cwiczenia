using System;
using CwiczeniaRESTAPI.Infrastructure.UnitOfWorks;
using CwiczeniaRESTAPI.SeedWork;
using NHibernate;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories
{
    public class BaseRepository
    {
        private readonly NHibernateUnitOfWork _unitOfWork;
     
        public BaseRepository(ITransactionUnitOfWork unitOfWork)
        {
            _unitOfWork = (NHibernateUnitOfWork)unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
        }

        public ISession Session => _unitOfWork.Session;

        public ITransactionUnitOfWork Transaction => _unitOfWork;

        public void Dispose()
        {
            Transaction.Dispose();
        }

    }
}