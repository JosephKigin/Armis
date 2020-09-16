using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.BusinessModels.ShopFloorModels.Department;
using Armis.DataLogic.Services.ShopFloorServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.ShopFloor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        public IDepartmentService DepartmentService { get; set; }

        public DepartmentController(IDepartmentService aDeptService, ILogger<DepartmentController> aLogger)
        {
            DepartmentService = aDeptService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetAllDepartments()
        {
            try
            {
                var data = await DepartmentService.GetAllDepartments();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("DepartmentController.GetAllDepartments() Not able to get all departments. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}
