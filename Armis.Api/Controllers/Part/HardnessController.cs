using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Part
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HardnessController : ControllerBase
    {
        private readonly ILogger<HardnessController> _logger;

        public IHardnessService HardnessService { get; set; }

        public HardnessController(IHardnessService aHardnessService, ILogger<HardnessController> aLogger)
        {
            HardnessService = aHardnessService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardnessModel>>> GetAllHardnesses()
        {
            try
            {
                var data = await HardnessService.GetAllHarnesses();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("HardnessController.GetAllHardnesses() Not able to get all hardnesses. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{aHardnessId}")]
        public async Task<ActionResult<HardnessModel>> GetHardness(int aHardnessId)
        {
            try
            {
                var data = await HardnessService.GetHardness(aHardnessId);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("HardnessController.GetHardness() Not able to get hardness for ID ({hardnessId}). | Message: {exMessage} | StackTrace: {stackTrace}", aHardnessId, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<HardnessModel>> CreateHardness(HardnessModel aHardnessModel)
        {
            try
            {
                var data = await HardnessService.CreateHardness(aHardnessModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("HardnessController.CreateHardness(HardnessModel aHardnessModel) Not able to create hardness ({hardnessModel}). | Message: {exMessage} | StackTrace: {stackTrace}", aHardnessModel, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}