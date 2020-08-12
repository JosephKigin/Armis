using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Quality.Inspection
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InspectTestTypeController : ControllerBase
    {
        private readonly ILogger<InspectTestTypeController> _logger;

        public IInspectTestTypeService InspectTestTypeService { get; set; }

        public InspectTestTypeController(IInspectTestTypeService anInspectTestTypeService, ILogger<InspectTestTypeController> aLogger)
        {
            _logger = aLogger;
            InspectTestTypeService = anInspectTestTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectTestTypeModel>>> GetAllTestTypes()
        {
            try
            {
                var data = await InspectTestTypeService.GetAllInspectTestType();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("InspectTestTypeController.GetAllTestTypes() Not able to get all test types. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<InspectTestTypeModel>> CreateInspectionTestType(InspectTestTypeModel anInspectTestTypeModel)
        {
            try
            {
                var data = await InspectTestTypeService.CreateInspectTestType(anInspectTestTypeModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("InspectTestTypeController.CreateInspectionTestType(InspectTestTypeModel anInspectTestTypeModel) Not able to create inspection test type {inspectTestType}. | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(anInspectTestTypeModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}