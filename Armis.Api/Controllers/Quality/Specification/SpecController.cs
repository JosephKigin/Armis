using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecController : ControllerBase
    {
        public ISpecService SpecService { get; set; }

        public SpecController(ISpecService aSpecService)
        {
            SpecService = aSpecService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecModel>>> GetAllSpecsWithCurrentRev() 
        {
            try
            {
                var data = await SpecService.GetAllSpecsWithCurrentRev();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecModel>>> GetAllHydratedSpecs()
        {
            try
            {
                var data = await SpecService.GetAllHydratedSpecs();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecModel>>> GetAllHydratedSpecsWithSamplePlans()
        {
            try
            {
                var data = await SpecService.GetAllHydratedSpecsWithSamplePlans();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecModel>>> GetAllHydratedSpecsWithOnlyCurrentRev()
        {
            try
            {
                var data = await SpecService.GetAllHydratedSpecsWithOnlyCurrentRev();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aSpecId}/{aSpecRevId}")]
        public async Task<ActionResult<IEnumerable<SpecSubLevelModel>>> GetHydratedSubLevelsForSpec(int aSpecId, short aSpecRevId)
        {
            try
            {
                var data = await SpecService.GetSpecSubLevels(aSpecId, aSpecRevId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aSpecId}")]
        public async Task<ActionResult<SpecModel>> GetHydratedCurrentRevOfSpec(int aSpecId)
        {
            try
            {
                var data = await SpecService.GetHydratedCurrentRevForSpec(aSpecId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNewSpec(SpecModel aSpecModel)
        {
            try
            {
                var data = await SpecService.CreateNewSpec(aSpecModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> RevUpSpec(SpecRevModel aSpecRevModel)
        {
            try
            {
                var data = await SpecService.RevUpSpec(aSpecRevModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}