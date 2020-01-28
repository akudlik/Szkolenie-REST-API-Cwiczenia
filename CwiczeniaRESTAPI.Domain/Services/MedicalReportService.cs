using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Services
{
    public class MedicalReportService : IMedicalReportService
    {
        private IMedicalReportRepository _MedicalReportRepository;

        public MedicalReportService(IMedicalReportRepository MedicalReportRepository)
        {
            _MedicalReportRepository = MedicalReportRepository;
        }


        public void Dispose()
        {
        }

        public Result<IEnumerable<MedicalReport>> GetAllTodayMedicalReport()
        {
            return Result<IEnumerable<MedicalReport>>.Ok(_MedicalReportRepository.GetListOfMedicalReports(100, 0).Value.Where(s => s.Date.Date == DateTime.Today));
        }
    }
}