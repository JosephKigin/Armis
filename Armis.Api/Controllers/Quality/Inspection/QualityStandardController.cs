using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Quality.Inspection
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QualityStandardController : ControllerBase
    {
        private readonly ILogger<QualityStandardController> _logger;

        public IQualityStandardService QualityStandardService { get; set; }

        public QualityStandardController(IQualityStandardService aQualityStandardService, ILogger<QualityStandardController> aLogger)
        {
            QualityStandardService = aQualityStandardService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualityStandardModel>>> GetAllQualityStandards()
        {
            try
            {
                var data = await QualityStandardService.GetAllQualityStandards();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("QualityStandardController.GetAllQualityStandards() Not able to get all quality standards. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}