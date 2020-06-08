using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ShippingModels;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.Shipping
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContainerTypeController : ControllerBase
    {
        public IContainerService ContainerService { get; set; }

        public ContainerTypeController(IContainerService aContainerService)
        {
            ContainerService = aContainerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContainerTypeModel>>> GetAllContainerTypes()
        {
            try
            {
                var data = await ContainerService.GetAllContainers();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}