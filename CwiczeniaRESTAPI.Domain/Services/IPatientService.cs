using System;
using System.Collections.Generic;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Services
{
    public interface IPatientService : IDisposable
    {
        Result DeactivatePatient(int id);
        
        Result<IEnumerable<MedicalReport>> GetAllPatientMedical(int id);
    }
}