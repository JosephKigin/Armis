using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Armis.Data.DatabaseContext.Entities;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecProcessAssignController : ControllerBase
    {
        private readonly ILogger<SpecProcessAssignController> _logger;

        public ISpecProcessAssignService SpecProcessAssignService { get; set; }

        public SpecProcessAssignController(ISpecProcessAssignService aSpecProcessAssignService, ILogger<SpecProcessAssignController> aLogger)
        {
            SpecProcessAssignService = aSpecProcessAssignService;
            _logger = aLogger;
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
                _logger.LogError("SpecProcessAssignController.GetSpecProcessAssign(int aSpecId, short aSpecRevId, short aSpecAssignId) Not able to get spec process assign. SpecId ({specId}) RevId({revId}) AssignId({assignId}) | Message: {exMessage} | StackTrace: {stackTrace}", aSpecId, aSpecRevId, aSpecAssignId, ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.GetAllHydratedSpecProcessAssign() Not able to get all hydrated spec process assigns. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.GetAllActiveHydratedSpecProcessAssign() Not able to get all active hydrated spec process assigns. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.GetAllActiveHydratedSpecProcessAssignForSpec(int aSpecId) Not able to get all active hydrated spec process assigns. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.GetAllHydratedReviewNeededSpecProcessAssigns() Not able to get all hydrated review needed spec process assigns. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aSpecId}")]
        public async Task<ActionResult<IEnumerable<SpecProcessAssignModel>>> GetHydratedHistorySpecProcessAssignForSpec(int aSpecId)
        {
            try
            {
                var data = await SpecProcessAssignService.GetHydratedHistorySpecProcessAssignsForSpec(aSpecId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("SpecProcessAssignController.GetHydratedHistorySpecProcessAssignForSpec(int aSpecId) Not able to get spec process assign history for spec ID ({specId}).  | Message: {exMessage} | StackTrace: {stackTrace}", aSpecId, ex.Message, ex.StackTrace);

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
                _logger.LogError("SpecProcessAssignController.CheckIfReviewIsNeededForSpecId(int aSpecId) Not able to check if review is needed spec process assign for spec ID ({specId}).  | Message: {exMessage} | StackTrace: {stackTrace}", aSpecId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{specId}/{internalSpecId}/{customer?}")]
        public async Task<ActionResult<bool>> VerifyUniqueChoices(int specId, short internalSpecRevId, int? customer, [FromBody]IEnumerable<SpecProcessAssignOptionModel> anOptionModels)
        {
            try
            {
                var data = await SpecProcessAssignService.VerifyUniqueChoices(specId, internalSpecRevId, customer, anOptionModels);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("SpecProcessAssignController.VerifyUniqueChoices(int specId, short internalSpecId, int? customer, [FromBody]IEnumerable<SpecProcessAssignOptionModel> anOptionModels) Not able to verify unique choices for spec ID ({specId}) rev ID ({revId}) customer ({cusomter}) SPA option model ({optionModel}).  | Message: {exMessage} | StackTrace: {stackTrace}", specId, internalSpecRevId, JsonSerializer.Serialize(anOptionModels), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{aSpecId}")]
        public async Task<ActionResult<bool>> CheckSpaIsViable(int aSpecId, [FromBody]IEnumerable<SpecProcessAssignOptionModel> anOptionModels = null)
        {
            try
            {
                var data = await SpecProcessAssignService.CheckSpaIsViable(aSpecId, anOptionModels);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("SpecProcessAssignController.CheckSpaIsViable(int aSpecId, [FromBody]IEnumerable<SpecProcessAssignOptionModel> anOptionModels = null) Not able to check if SPA is viable. Spec ID ({specId}) Option Models ({optionModels})  | Message: {exMessage} | StackTrace: {stackTrace}", aSpecId, JsonSerializer.Serialize(anOptionModels), ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.PostSpecProcessAssign(SpecProcessAssignModel aSpecProcessAssignModel) Not able to create spec process assign ({spa}).  | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aSpecProcessAssignModel), ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.RemoveReviewNeeded(SpecProcessAssignModel aSpecProcessAssignModel) Not able to remove review needed for spec process assign ({spa}).  | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aSpecProcessAssignModel), ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecProcessAssignController.CopyAfterReview(SpecProcessAssignModel aSpecProcessAssignModel) Not able to copy after review needed for spec process assign ({spa}).  | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aSpecProcessAssignModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}