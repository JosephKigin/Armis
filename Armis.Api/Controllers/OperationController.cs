using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.ProcessModels;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        public IOperationService OperationService { get; set; }

        public OperationController(IOperationService anOperationService)
        {
            OperationService = anOperationService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}