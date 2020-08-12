using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Process;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;

        public IOperationService OperationService { get; set; }

        public OperationController(IOperationService anOperationService, ILogger<OperationController> aLogger)
        {
            OperationService = anOperationService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationModel>>> GetAllOperations()
        {
            try
            {
                var data = await OperationService.GetAllOperations();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OperationController.GetAllOperations() Not able to get all operations. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationGroupModel>>> GetAllOperationGroups()
        {
            try
            {
                var data = await OperationService.GetAllOperationGroups();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OperationController.GetAllOperationGroups() Not able to get all operation groups. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateOperation(OperationModel anOperationModel)
        {
            try
            {
                var data = await OperationService.AddOperation(anOperationModel);

                return Ok (JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OperationController.CreateOperation(OperationModel anOperationModel) Not able to create operation ({operation}). | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(anOperationModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOperation(OperationModel anOperationModel) //This model NEEDS to have an Id. 
        {
            try
            {
                var data = await OperationService.UpdateOperation(anOperationModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OperationController.UpdateOperation(OperationModel anOperationModel) Not able to update operation {operation}. | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(anOperationModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}