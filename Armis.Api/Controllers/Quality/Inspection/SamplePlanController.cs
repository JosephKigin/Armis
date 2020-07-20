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

namespace Armis.Api.Controllers.Quality.Inspection
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SamplePlanController : ControllerBase
    {
        public ISamplePlanService SamplePlanService { get; set; }

        public SamplePlanController(ISamplePlanService aSamplePlanService)
        {
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SamplePlanModel>> CreateHydratedSamplePlan(SamplePlanModel aSamplePlanModel)
        {
            try
            {
                var data = await SamplePlanService.CreateSamplePlan(aSamplePlanModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}