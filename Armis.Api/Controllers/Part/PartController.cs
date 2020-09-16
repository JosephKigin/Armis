using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.BusinessModels.PartModels;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Armis.Api.Controllers.Part
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly ILogger<PartController> _logger;

        public IPartService PartService { get; set; }

        public PartController(IPartService aPartService, ILogger<PartController> aLogger)
        {
            PartService = aPartService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartModel>>> GetAllParts()
        {
            try
            {
                var data = await PartService.GetAllParts();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("PartController.GetAllParts() Not able to get all parts. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aCustId}")]
        public async Task<ActionResult<IEnumerable<PartModel>>> GetPartsForCustId(int aCustId)
        {
            try
            {
                var data = await PartService.GetPartsForCustId(aCustId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("PartController.GetPartsForCustId(int aCustId) Not able to get parts for customer ID {aCustId}. | Message: {exMessage} | StackTrace: {stackTrace}", aCustId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PartModel>> CreatePart(PartModel aPartModel)
        {
            try
            {
                var data = await PartService.CreatePart(aPartModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("PartController.CreatePart(PartModel aPartModel) Not able to create part {aPartModel}. | Message: {exMessage} | StackTrace: {stackTrace}", aPartModel, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{aCustId}")]
        public async Task<ActionResult<PartModel>> CreatePartWithCustomerPart([FromBody] PartModel aPartModel, int aCustId)
        {
            try
            {
                var data = await PartService.CreatePartWithCustomerPart(aPartModel, aCustId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("PartController.CreatePart(PartModel aPartModel) Not able to create part {aPartModel} Customer: {aCustomerId}. | Message: {exMessage} | StackTrace: {stackTrace}", aPartModel, aCustId, ex.Message, ex.StackTrace);
                throw;
            }
        }
    }
}
