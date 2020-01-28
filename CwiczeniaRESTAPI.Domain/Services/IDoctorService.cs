using System;
using System.Collections.Generic;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Services
{
    public interface IDoctorService : IDisposable
    {
        Result<IEnumerable<MedicalReport>> GetAllDoctorMedical(int id);
        
        Result<IEnumerable<Patient>> GetAllDoctorPatients(int id);
    }
}