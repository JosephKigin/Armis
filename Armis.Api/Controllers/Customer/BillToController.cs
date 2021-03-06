﻿using System;
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
    public class BillToController : ControllerBase
    {
        private readonly ILogger<BillToController> _logger;
        public IBillToService BillToService { get; set; }

        public BillToController(IBillToService aBillToService, ILogger<BillToController> aLogger)
        {
            BillToService = aBillToService;
            _logger = aLogger;
        }

        [HttpGet("{aCustomerId}")]
        public async Task<ActionResult<BillToModel>> GetBillToByCustId(int aCustomerId)
        {
            try
            {
                var data = await BillToService.GetBillToByCustId(aCustomerId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("BillToController.GetAllBillToByCustId(int customerId) Not able to pull BillTo for customer with id {customerId}. | Message: {exMessage} | StackTrace: {stackTrace}", aCustomerId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}