using System.Collections.Generic;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate
{
    public interface IMedicalReportRepository : IRepository<MedicalReport>
    {
        Result<IEnumerable<MedicalReport>> GetListOfMedicalReports(int pageSize, int pageNumber);

        Result<MedicalReport> GetOneMedicalReport(int id);

        Result<MedicalReport> CreateMedicalReport(MedicalReport MedicalReport);

        Result<MedicalReport> UpdateMedicalReport(MedicalReport MedicalReport);

        Result DeleteMedicalReport(int id);
    }
}