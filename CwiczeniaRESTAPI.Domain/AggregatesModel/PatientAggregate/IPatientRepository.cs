using System.Collections.Generic;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.AggregatesModel.PatientAggregate
{
    public interface IPatientRepository:IRepository<Patient>
    {
        Result<IEnumerable<Patient>> GetListOfPatients(int pageSize, int pageNumber);
        
        Result<Patient> GetOnePatient(int id);
        
        Result<Patient> CreatePatient(Patient patient);
        
        Result<Patient> UpdatePatient(Patient patient);
        
        Result DeletePatient(int id);
    }
}