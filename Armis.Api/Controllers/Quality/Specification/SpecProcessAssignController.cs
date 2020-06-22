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

        [HttpGet("{specId}/{internalSpecId}/{choice1}/{choice2}/{choice3}/{choice4}/{choice5}/{choice6}/{preBake}/{postBake}/{mask}/{hardness}/{series}/{alloy}/{customer}")]
        public async Task<ActionResult<bool>> VerifyUniqueChoices(int specId, short internalSpecId, int? choice1, int? choice2, int? choice3, int? choice4, int? choice5, int? choice6, int? preBake, int? postBake, int? mask, int? hardness, int? series, int? alloy, int? customer)
        {
            try
            {
                choice1 = (choice1 == 0) ? null : choice1;
                choice2 = (choice2 == 0) ? null : choice2;
                choice3 = (choice3 == 0) ? null : choice3;
                choice4 = (choice4 == 0) ? null : choice4;
                choice5 = (choice5 == 0) ? null : choice5;
                choice6 = (choice6 == 0) ? null : choice6;
                preBake = (preBake == 0) ? null : preBake;
                postBake = (postBake == 0) ? null : postBake;
                mask = (mask == 0) ? null : mask;
                hardness = (hardness == 0) ? null : hardness;
                series = (series == 0) ? null : series;
                alloy = (alloy == 0) ? null : alloy;
                customer = (customer == 0) ? null : customer;

                var data = await SpecProcessAssignService.VerifyUniqueChoices(specId, internalSpecId, choice1, choice2, choice3, choice4, choice5, choice6, preBake, postBake, mask, hardness, series, alloy, customer);

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
    }
}