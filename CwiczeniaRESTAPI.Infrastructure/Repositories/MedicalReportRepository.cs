using System;
using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Infrastructure.Repositories
{
    public class MedicalReportRepository : BaseRepository, IMedicalReportRepository
    {
        public MedicalReportRepository(ITransactionUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Result<IEnumerable<MedicalReport>> GetListOfMedicalReports(int pageSize, int pageNumber)
        {
            var query = Session.Query<MedicalReport>();
            query = query.Take(pageSize)
                .Skip(pageNumber * pageSize);

            var result = query.ToList();

            foreach (var res in result)
            {
                var dd = res.Doctor;
                var d = res.Patient;
            }

            return Result<IEnumerable<MedicalReport>>.Ok(result);
        }

        public Result<MedicalReport> GetOneMedicalReport(int id)
        {
            var result = Session.Get<MedicalReport>(id);

            return Result<MedicalReport>.Ok(result);
        }

        public Result<MedicalReport> CreateMedicalReport(MedicalReport MedicalReport)
        {
            try
            {
                using (var transaction = Transaction.BeginTransaction())
                {
 
                    Session.Save(MedicalReport);
                    transaction.Commit();
                    return Result<MedicalReport>.Ok(MedicalReport);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Result<MedicalReport> UpdateMedicalReport(MedicalReport MedicalReport)
        {
            using (var transaction = Transaction.BeginTransaction())
            {
                Session.Update(MedicalReport);
                transaction.Commit();
            }

            return Result<MedicalReport>.Ok(MedicalReport);
        }

        public Result DeleteMedicalReport(int id)
        {
            Session.Delete(id);

            return Result.Ok();
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}