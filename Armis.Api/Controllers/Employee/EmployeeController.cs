using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.EmployeeModels;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        public IEmployeeService EmployeeService { get; set; }

        public EmployeeController(IEmployeeService anEmpService, ILogger<EmployeeController> aLogger)
        {
            EmployeeService = anEmpService;
            _logger = aLogger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeById(int id)
        {
            try
            {
                var data = await EmployeeService.GetEmployeeById(id);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ContactController.GetEmployeeById(int id) Not able to get employee for ID ({employeeId}). | Message: {exMessage} | StackTrace: {stackTrace}", id, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> CheckIfEmployeeNumberExists(int id)
        {
            try
            {
                var data = await EmployeeService.CheckIfEmployeeNumberExists(id);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("ContactController.CheckIfEmployeeNumberExists(int id) Not able to check if employee exists for ID ({employeeId}). | Message: {exMessage} | StackTrace: {stackTrace}", id, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}