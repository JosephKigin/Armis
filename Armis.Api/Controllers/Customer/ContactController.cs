using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.CustomerModels;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.Customer
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public IContactService ContactService { get; set; }

        public ContactController(IContactService aContactService)
        {
            ContactService = aContactService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetAllHydratedContactsByCust(int customerId)
        {
            try
            {
                var data = await ContactService.GetAllHydratedContactsByCustomer(customerId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}