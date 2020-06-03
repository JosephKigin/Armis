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

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ARMISContext _context;
        public ICustomerService CustomerService { get; set; }

        public CustomersController(ARMISContext aContext, ICustomerService aCustomerService)
        {
            _context = aContext;
            CustomerService = aCustomerService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}
