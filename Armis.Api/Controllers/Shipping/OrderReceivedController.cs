using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Armis.DataLogic.Services.ShippingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Armis.BusinessModels.ShippingModels;

namespace Armis.Api.Controllers.Shipping
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderReceivedController : ControllerBase
    {
        private readonly ILogger<OrderReceivedController> _logger;

        public IOrderReceivedService OrderReceivedService { get; set; }

        public OrderReceivedController(IOrderReceivedService anOrderReceivedService, ILogger<OrderReceivedController> aLogger)
        {
            OrderReceivedService = anOrderReceivedService;
            _logger = aLogger;
        }

        [HttpGet("{anOrderId}")]
        public async Task<ActionResult<short>> GetNextReceivedNumberForOrderId(int anOrderId)
        {
            try
            {
                var data = await OrderReceivedService.GetNextReceivedNumberForOrderId(anOrderId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderReceivedController.GetNextReceivedNumberForOrderId(int anOrderId) Not able to get next received number for order {anOrderId}. | Message: {exMessage} | StackTrace: {stackTrace}", anOrderId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{anOrderId}")]
        public async Task<ActionResult<IEnumerable<OrderReceivedModel>>> GetOrderReceivedsForOrderId(int anOrderId)
        {
            try
            {
                var data = await OrderReceivedService.GetOrderReceivedsForOrderId(anOrderId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderReceivedController.GetOrderReceivedsForOrderId(int anOrderId) Not able to get order receiveds for {anOrderId}. | Message: {exMessage} | StackTrace: {stackTrace}", anOrderId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderReceivedModel>> CreateOrderReceived(OrderReceivedModel anOrderReceivedModel)
        {
            try
            {
                var data = await OrderReceivedService.CreateOrderReceived(anOrderReceivedModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("OrderReceivedController.CreateOrderReceived(int anOrderId) Not able to create order received {anOrderReceived}. | Message: {exMessage} | StackTrace: {stackTrace}", anOrderReceivedModel, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}
