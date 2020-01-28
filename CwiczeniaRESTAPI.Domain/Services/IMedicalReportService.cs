using System;
using System.Collections;
using System.Collections.Generic;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Services
{
    public interface IMedicalReportService : IDisposable
    {
        Result<IEnumerable<MedicalReport>> GetAllTodayMedicalReport();
    }
}