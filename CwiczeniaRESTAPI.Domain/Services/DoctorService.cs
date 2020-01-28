using System.Collections.Generic;
using System.Linq;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.SeedWork;

namespace CwiczeniaRESTAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _DoctorRepository;

        public DoctorService(IDoctorRepository DoctorRepository)
        {
            _DoctorRepository = DoctorRepository;
        }


        public Result<IEnumerable<MedicalReport>> GetAllDoctorMedical(int id)
        {
            var result = _DoctorRepository.GetOneDoctor(id);

            return Result<IEnumerable<MedicalReport>>.Ok(result.Value.MedicalReports);
        }

        public Result<IEnumerable<Patient>> GetAllDoctorPatients(int id)
        {
            var result = GetAllDoctorMedical(id);

            return Result<IEnumerable<Patient>>.Ok(result.Value.Select(s => s.Patient).ToList());
        }


        public void Dispose()
        {
        }
    }
}