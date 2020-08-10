using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ShippingModels;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Shipping
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContainerTypeController : ControllerBase
    {
        private readonly ILogger<ContainerTypeController> _logger;

        public IContainerService ContainerService { get; set; }

        public ContainerTypeController(IContainerService aContainerService, ILogger<ContainerTypeController> aLogger)
        {
            ContainerService = aContainerService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContainerModel>>> GetAllContainerTypes()
        {
            try
            {
                var data = await ContainerService.GetAllContainers();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ContainerTypeController.GetAllContainerTypes() Not able to get all container types. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}