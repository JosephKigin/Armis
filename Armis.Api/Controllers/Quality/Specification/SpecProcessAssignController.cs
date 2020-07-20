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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecProcessAssignModel>>> GetAllHydratedSpecProcessAssign()
        {
            try
            {
                var data = await SpecProcessAssignService.GetAllHydratedSpecProcessAssign();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecProcessAssignModel>>> GetAllActiveHydratedSpecProcessAssign()
        {
            try
            {
                var data = await SpecProcessAssignService.GetAllActiveHydratedSpecProcessAssign();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aSpecId}")]
        public async Task<ActionResult<IEnumerable<SpecProcessAssignModel>>> GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId)
        {
            try
            {
                var data = await SpecProcessAssignService.GetAllActiveHydratedSpecProcessAssignForSpec(aSpecId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecProcessAssignModel>>> GetAllHydratedReviewNeededSpecProcessAssigns()
        {
            try
            {
                var data = await SpecProcessAssignService.GetAllHydratedReviewNeeded();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aSpecId}")]
        public async Task<ActionResult<bool>> CheckIfReviewIsNeededForSpecId(int aSpecId)
        {
            try
            {
                var data = await SpecProcessAssignService.CheckIfReviewIsNeededForSpecId(aSpecId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{specId}/{internalSpecId}/{customer?}")]
        public async Task<ActionResult<bool>> VerifyUniqueChoices(int specId, short internalSpecId, int? customer, [FromBody]IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            try
            {
                var data = await SpecProcessAssignService.VerifyUniqueChoices(specId, internalSpecId, customer, anOptionModels);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{aSpecId}")]
        public async Task<ActionResult<bool>> CheckSpaIsViable(int aSpecId, [FromBody]IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            try
            {
                var data = await SpecProcessAssignService.CheckSpaIsViable(aSpecId, anOptionModels);

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

        [HttpPost]
        public async Task<ActionResult<SpecProcessAssignModel>> RemoveReviewNeeded(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            try
            {
                var data = await SpecProcessAssignService.RemoveReviewNeeded(aSpecProcessAssignModel.SpecId, aSpecProcessAssignModel.SpecRevId, aSpecProcessAssignModel.SpecAssignId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SpecProcessAssignModel>> CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel)
        {
            try
            {
                var data = await SpecProcessAssignService.CopyAfterReview(aSpecProcessAssignModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{aCustomer}")]
        public ActionResult<int> TestStuff(int aCustomer, [FromBody]int aSpecId)
        {
            return Ok(JsonSerializer.Serialize(aCustomer + aSpecId));
        }
    }
}