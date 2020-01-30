using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(ITransactionUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Result<IEnumerable<Patient>> GetListOfPatients(int pageSize, int pageNumber)
        {
            var query = Session.Query<Patient>();
            query = query.Take(pageSize)
                .Skip(pageNumber * pageSize);

            var result = query.ToList();
            return Result<IEnumerable<Patient>>.Ok(result);
        }

        public Result<Patient> GetOnePatient(int id)
        {
            var result = Session.Get<Patient>(id);

            return Result<Patient>.Ok(result);
        }

        public Result<Patient> CreatePatient(Patient patient)
        {
            using (var transaction = Transaction.BeginTransaction())
            {
                Session.Save(patient);
                transaction.Commit();
                return Result<Patient>.Ok(patient);
            }
        }

        public Result<Patient> UpdatePatient(Patient patient)
        {
            using (var transaction = Transaction.BeginTransaction())
            {
                Session.Update(patient);
                transaction.Commit();
            }

            return Result<Patient>.Ok(patient);
        }

        public Result DeletePatient(int id)
        {
            var result = GetOnePatient(id);
            
            Session.Delete(result.Value);

            return Result.Ok();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}