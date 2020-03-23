using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels.Spec;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
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
    }
}