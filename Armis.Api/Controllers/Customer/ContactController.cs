using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.CustomerModels;
using Armis.DataLogic.Services.CustomerServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Customer
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        public IContactService ContactService { get; set; }

        public ContactController(IContactService aContactService, ILogger<ContactController> aLogger)
        {
            ContactService = aContactService;
            _logger = aLogger;
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
                _logger.LogError("ContactController.GetAllHydratedContactsByCust(int customerId) Not able to get hydrated contacts for customer ID ({customerId}). | Message: {exMessage} | StackTrace: {stackTrace}", customerId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}