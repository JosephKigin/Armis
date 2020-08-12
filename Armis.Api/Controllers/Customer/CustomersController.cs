using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Armis.BusinessModels.Customer;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        public ICustomerService CustomerService { get; set; }

        public CustomersController(ICustomerService aCustomerService, ILogger<CustomersController> aLogger)
        {
            CustomerService = aCustomerService;
            _logger = aLogger;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            try
            {
                var data = await CustomerService.GetAllCustomers();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("CustomersController.GetCustomers() Not able to get all customers. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetAllHydratedCustomers()
        {
            try
            {
                var data = await CustomerService.GetAllHydratedCustomers();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("CustomersController.GetAllHydratedCustomers() Not able to get all customers. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetAllCurrentAndProspectCustomers()
        {
            try
            {
                var data = await CustomerService.GetAllCurrentAndProspectCustomers();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("CustomersController.GetAllCurrentAndProspectCustomers() Not able to get all current and prospect customers. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}
