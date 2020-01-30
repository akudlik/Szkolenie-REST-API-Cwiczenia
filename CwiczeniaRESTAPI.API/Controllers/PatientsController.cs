using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using Microsoft.AspNetCore.Mvc;

namespace CwiczeniaRESTAPI.API.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientsController : Controller
    {
        private IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllPatients()
        {
            var listOfPatients = _patientRepository.GetListOfPatients(100, 0);
            var mappedPatients = AutoMapper.Mapper.Map<IList<Patient>>(listOfPatients.Value);
            return Ok(mappedPatients);
        }

        [HttpGet]
        [Route("{patientId:int}")]
        public IActionResult GetOnePatient([Required] int patientId)
        {
            var listOfPatients = _patientRepository.GetOnePatient(patientId);
            var mappedPatients = AutoMapper.Mapper.Map<Patient>(listOfPatients.Value);
            return Ok(mappedPatients);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            var listOfPatients = _patientRepository.CreatePatient(patient);
            var mappedPatients = AutoMapper.Mapper.Map<Patient>(listOfPatients.Value);
            return Ok(mappedPatients);
        }

        [HttpPut]
        [Route("{patientId:int}")]
        public IActionResult UpdatePatient([Required] int patientId, [FromBody] Patient patient)
        {
            var listOfPatients = _patientRepository.UpdatePatient(patient);
            return NoContent();
        }
        
        
        [HttpDelete]
        [Route("{patientId:int}")]
        public IActionResult DeletePatient([Required] int patientId)
        {
            var listOfPatients = _patientRepository.DeletePatient(patientId);
            return NoContent();
        }
    }
}