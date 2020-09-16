using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.BusinessModels.PartModels;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Part
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitOfMeasureController : ControllerBase
    {
        private readonly ILogger<UnitOfMeasureController> _logger;

        public IUnitOfMeasureService UoMService { get; set; }

        public UnitOfMeasureController(ILogger<UnitOfMeasureController> aLogger, IUnitOfMeasureService aUoMService)
        {
            _logger = aLogger;
            UoMService = aUoMService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasureModel>>> GetAllUoMs()
        {
            try
            {
                var data = await UoMService.GetAllUoMs();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("UnitOfMeasureController.GetAllUoMs() Not able to get all UoMs. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}
