using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CwiczeniaRESTAPI.AggregatesModel.PatientAggregate;
using CwiczeniaRESTAPI.API.Model;
using Microsoft.AspNetCore.Mvc;
using Patient = CwiczeniaRESTAPI.API.Model.Patient;

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
        public IActionResult GetAllPatients([FromQuery] Pagination pagination)
        {
            var listOfPatients = _patientRepository.GetListOfPatients(pagination.PageSize, pagination.PageNumber);
            var mappedPatients = AutoMapper.Mapper.Map<IList<Patient>>(listOfPatients.Value);
            return Ok(mappedPatients);
        }

        [HttpGet]
        [Route("{patientId:int}")]
        public IActionResult GetOnePatient([Required] int patientId)
        {
            var listOfPatients = _patientRepository.GetOnePatient(patientId);
            var mappedPatients = AutoMapper.Mapper.Map<Patient>(listOfPatients.Value);

            if (mappedPatients == null)
                return NotFound("Not found patient");
            
            return Ok(mappedPatients);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            var domain = AutoMapper.Mapper.Map<CwiczeniaRESTAPI.AggregatesModel.PatientAggregate.Patient>(patient);
            var listOfPatients = _patientRepository.CreatePatient(domain);
            var mappedPatients = AutoMapper.Mapper.Map<Patient>(listOfPatients.Value);
            return Ok(mappedPatients);
        }

        [HttpPut]
        [Route("{patientId:int}")]
        public IActionResult UpdatePatient([Required] int patientId, [FromBody] Patient patient)
        {
            var domain = AutoMapper.Mapper.Map<CwiczeniaRESTAPI.AggregatesModel.PatientAggregate.Patient>(patient);
            var listOfPatients = _patientRepository.UpdatePatient(domain);
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