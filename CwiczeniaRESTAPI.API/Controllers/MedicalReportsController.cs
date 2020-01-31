using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate;
using CwiczeniaRESTAPI.API.Model;
using CwiczeniaRESTAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using MedicalReport = CwiczeniaRESTAPI.API.Model.MedicalReport;

namespace CwiczeniaRESTAPI.API.Controllers
{
    [Route("api/MedicalReports")]
    [SwaggerTag("MedicalReports information")]
    [ApiController]
    public class MedicalReportsController : Controller
    {
        private IMedicalReportRepository _medicalReportRepository;

        public MedicalReportsController(IMedicalReportRepository medicalReportRepository)
        {
            _medicalReportRepository = medicalReportRepository;
        }

        [HttpGet]
        [Route("")]
        [SwaggerOperation(Summary = "Get all MedicalReports", Description = "Returns all MedicalReports from data base")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<MedicalReport>), Description = "Array of all MedicalReports")]
        public IActionResult GetAllMedicalReports([FromQuery] Pagination pagination)
        {
            var listOfMedicalReports = _medicalReportRepository.GetListOfMedicalReports(pagination.PageSize, pagination.PageNumber);
            var mappedMedicalReports = AutoMapper.Mapper.Map<IList<MedicalReport>>(listOfMedicalReports.Value);
            return Ok(mappedMedicalReports);
        }

        /// <summary>
        /// Returns MedicalReport by given identifier
        /// </summary>
        /// <param name="medicalReportId"></param>
        /// <returns>Medical report (ex. blood)</returns>
        /// <response code="200">Medical report (ex. blood)</response> 
        /// <response code="404">Not found medical report</response>             
        [HttpGet]
        [SwaggerOperation(Summary = "Get MedicalReport by given id", Description = "Returns MedicalReport by given identifier")]
        [ProducesResponseType(typeof(MedicalReport),StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [Route("{medicalReportId:int}")]
        public IActionResult GetOneMedicalReport([Required] int medicalReportId)
        {
            var listOfMedicalReports = _medicalReportRepository.GetOneMedicalReport(medicalReportId);
            var mappedMedicalReports = AutoMapper.Mapper.Map<MedicalReport>(listOfMedicalReports.Value);
            return Ok(mappedMedicalReports);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add MedicalReport", Description = "Add given MedicalReport to data base")]
        [SwaggerResponse(201, Type = typeof(string), Description = "New MedicalReport object created")]
        [SwaggerResponse(400, Type = typeof(string), Description = "Incorrect MedicalReport given")]
        [Route("")]
        public IActionResult CreateMedicalReport([FromBody] MedicalReport medicalReport)
        {
            var domain = AutoMapper.Mapper.Map<CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate.MedicalReport>(medicalReport);
            var listOfMedicalReports = _medicalReportRepository.CreateMedicalReport(domain);
            var mappedMedicalReports = AutoMapper.Mapper.Map<MedicalReport>(listOfMedicalReports.Value);
            return Ok(mappedMedicalReports);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update MedicalReport of id", Description = "Update MedicalReport of given identifier with given MedicalReport value")]
        [SwaggerResponse(200, Type = typeof(MedicalReport), Description = "MedicalReport object updated")]
        [SwaggerResponse(400, Type = typeof(string), Description = "MedicalReport was incorrect")]
        [SwaggerResponse(404, Type = typeof(string), Description = "Not found MedicalReport of given identifier")]
        [Route("{medicalReportId:int}")]
        public IActionResult UpdateMedicalReport([Required] int medicalReportId, [FromBody] MedicalReport medicalReport)
        {
            var domain = AutoMapper.Mapper.Map<CwiczeniaRESTAPI.AggregatesModel.MedicalReportAggregate.MedicalReport>(medicalReport);
            var listOfMedicalReports = _medicalReportRepository.UpdateMedicalReport(domain);
            return NoContent();
        }


        [HttpDelete]
        [SwaggerOperation(Summary = "Delete MedicalReport", Description = "Remove MedicalReport of given identifier from data base")]
        [SwaggerResponse(204, Type = typeof(void), Description = "MedicalReport deleted")]
        [SwaggerResponse(404, Type = typeof(string), Description = "Not found MedicalReport of given identifier")]
        [Route("{medicalReportId:int}")]
        public IActionResult DeleteMedicalReport([Required] int medicalReportId)
        {
            var listOfMedicalReports = _medicalReportRepository.DeleteMedicalReport(medicalReportId);
            return NoContent();
        }
    }
}