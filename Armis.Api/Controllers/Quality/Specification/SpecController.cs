using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    //ToDo: What is the point of having one method that pulls hydrated specs and a different method that pulls hydrated specs with SamplePlans?  Cant the original hydrated call pull sample plans by default?
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecController : ControllerBase
    {
        private readonly ILogger<SpecController> _logger;

        public ISpecService SpecService { get; set; }

        public SpecController(ISpecService aSpecService, ILogger<SpecController> aLogger)
        {
            SpecService = aSpecService;
            _logger = aLogger;
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
                _logger.LogError("SpecController.GetAllSpecsWithCurrentRev() Not able to get all specs with current revs. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.GetAllHydratedSpecs() Not able to get all hydrated specs. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.GetAllHydratedSpecsWithSamplePlans() Not able to get all hydrated specs. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.GetAllHydratedSpecsWithOnlyCurrentRev() Not able to get all hydrated specs with only current rev. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.GetHydratedSubLevelsForSpec(int aSpecId, short aSpecRevId) Not able to get hydrated sublevels. SpecId({specId}) RevId({revId}) | Message: {exMessage} | StackTrace: {stackTrace}", aSpecId, aSpecRevId, ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.GetHydratedCurrentRevOfSpec(int aSpecId) Not able to get hydrated current revision for specId ({specId}). | Message: {exMessage} | StackTrace: {stackTrace}", aSpecId, ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.CreateNewSpec(SpecModel aSpecModel) Not able to create new spec ({spec}). | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aSpecModel), ex.Message, ex.StackTrace);
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
                _logger.LogError("SpecController.RevUpSpec(SpecRevModel aSpecRevModel) Not able to rev up spec revision ({specRev}). | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aSpecRevModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}