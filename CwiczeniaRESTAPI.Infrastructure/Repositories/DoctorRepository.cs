using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(ITransactionUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Result<IEnumerable<Doctor>> GetListOfDoctors(int pageSize, int pageNumber)
        {
            var query = Session.Query<Doctor>();
            query = query.Take(pageSize)
                .Skip(pageNumber * pageSize);

            var result = query.ToList();
            return Result<IEnumerable<Doctor>>.Ok(result);
        }

        public Result<Doctor> GetOneDoctor(int id)
        {
            var result = Session.Get<Doctor>(id);

            return Result<Doctor>.Ok(result);
        }

        public Result<Doctor> CreateDoctor(Doctor Doctor)
        {
            using (var transaction = Transaction.BeginTransaction())
            {
                Session.Save(Doctor);
                transaction.Commit();
                return Result<Doctor>.Ok(Doctor);
            }
        }

        public Result<Doctor> UpdateDoctor(Doctor Doctor)
        {
            using (var transaction = Transaction.BeginTransaction())
            {
                Session.Update(Doctor);
                transaction.Commit();
            }

            return Result<Doctor>.Ok(Doctor);
        }

        public Result DeleteDoctor(int id)
        {
            Session.Delete(id);

            return Result.Ok();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}