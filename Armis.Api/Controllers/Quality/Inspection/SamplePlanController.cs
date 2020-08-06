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
    public class SamplePlanController : ControllerBase
    {
        private readonly ILogger<SamplePlanController> _logger;

        public ISamplePlanService SamplePlanService { get; set; }

        public SamplePlanController(ISamplePlanService aSamplePlanService, ILogger<SamplePlanController> aLogger)
        {
            _logger = aLogger;
            SamplePlanService = aSamplePlanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SamplePlanModel>>> GetAllSamplePlans()
        {
            try
            {
                var data = await SamplePlanService.GetAllSamplePlans();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("SamplePlanController.GetAllSamplePlans() Not able to get all sample plans. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SamplePlanModel>>> GetAllHydratedSamplePlans()
        {
            try
            {
                var data = await SamplePlanService.GetAllHydratedSamplePlans();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("SamplePlanController.GetAllHydratedSamplePlans() Not able to get all hydrated sample plans. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SamplePlanModel>> CreateHydratedSamplePlan(SamplePlanModel aSamplePlanModel) //ToDo: Create hydrated? Does that make sense?
        {
            try
            {
                var data = await SamplePlanService.CreateSamplePlan(aSamplePlanModel);
                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("SamplePlanController.CreateHydratedSamplePlan(SamplePlanModel aSamplePlanModel) Not able to create sample plan {samplePlan}. | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aSamplePlanModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}