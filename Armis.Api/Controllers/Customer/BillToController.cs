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
    public class BillToController : ControllerBase
    {
        public IBillToService BillToService { get; set; }

        public BillToController(IBillToService aBillToService)
        {
            BillToService = aBillToService;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<BillToModel>> GetAllBillToByCustId(int customerId)
        {
            try
            {
                var data = await BillToService.GetBillToByCustId(customerId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}