using System.Collections.Generic;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Services
{
    public class PatientService : IPatientService
    {
        private IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Result DeactivatePatient(int id)
        {
            var patient = _patientRepository.GetOnePatient(id);
            patient.Value.Active = false;
            _patientRepository.UpdatePatient(patient.Value);

            return Result.Ok();
        }

        public Result<IEnumerable<MedicalReport>> GetAllPatientMedical(int id)
        {
            var result = _patientRepository.GetOnePatient(id);

            return Result<IEnumerable<MedicalReport>>.Ok(result.Value.MedicalReports);
        }

        public void Dispose()
        {
        }
    }
}