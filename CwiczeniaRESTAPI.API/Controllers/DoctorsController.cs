using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate;
using CwiczeniaRESTAPI.API.Model;
using Microsoft.AspNetCore.Mvc;
using Doctor = CwiczeniaRESTAPI.API.Model.Doctor;

namespace CwiczeniaRESTAPI.API.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    public class DoctorsController : Controller
    {
        private IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllDoctors([FromQuery] Pagination pagination)
        {
            var listOfDoctors = _doctorRepository.GetListOfDoctors(pagination.PageSize, pagination.PageNumber);
            var mappedDoctors = AutoMapper.Mapper.Map<IList<Doctor>>(listOfDoctors.Value);
            return Ok(mappedDoctors);
        }

        [HttpGet]
        [Route("{doctorId:int}")]
        public IActionResult GetOneDoctor([Required] int doctorId)
        {
            var listOfDoctors = _doctorRepository.GetOneDoctor(doctorId);
            var mappedDoctors = AutoMapper.Mapper.Map<Doctor>(listOfDoctors.Value);
            return Ok(mappedDoctors);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateDoctor([FromBody] Doctor doctor)
        {
            var domain = AutoMapper.Mapper.Map<CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate.Doctor>(doctor);
            var listOfDoctors = _doctorRepository.CreateDoctor(domain);
            var mappedDoctors = AutoMapper.Mapper.Map<Doctor>(listOfDoctors.Value);
            return Ok(mappedDoctors);
        }

        [HttpPut]
        [Route("{doctorId:int}")]
        public IActionResult UpdateDoctor([Required] int doctorId, [FromBody] Doctor doctor)
        {
            var domain = AutoMapper.Mapper.Map<CwiczeniaRESTAPI.AggregatesModel.DoctorAggregate.Doctor>(doctor);
            var listOfDoctors = _doctorRepository.UpdateDoctor(domain);
            return NoContent();
        }


        [HttpDelete]
        [Route("{doctorId:int}")]
        public IActionResult DeleteDoctor([Required] int doctorId)
        {
            var listOfDoctors = _doctorRepository.DeleteDoctor(doctorId);
            return NoContent();
        }
    }
}