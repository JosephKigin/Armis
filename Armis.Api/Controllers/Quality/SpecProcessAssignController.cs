using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecProcessAssignController : ControllerBase
    {
        public ISpecProcessAssignService SpecProcessAssignService { get; set; }

        public SpecProcessAssignController(ISpecProcessAssignService aSpecProcessAssignService)
        {
            SpecProcessAssignService = aSpecProcessAssignService;
        }

        [HttpGet("{aSpecId}/{aSpecRevId}/{aSpecAssignId}")]
        public async Task<ActionResult<SpecProcessAssignModel>> GetSpecProcessAssign(int aSpecId, short aSpecRevId, short aSpecAssignId)
        {
            try
            {
                var data = await SpecProcessAssignService.GetSpecProcessAssign(aSpecId, aSpecRevId, aSpecAssignId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SpecProcessAssignModel>> PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            try
            {
                var data = await SpecProcessAssignService.PostSpecProcessAssign(aSpecProcessAssignModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}