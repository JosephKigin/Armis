using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.Quality.Inspection
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QualityStandardController : ControllerBase
    {
        public IQualityStandardService QualityStandardService { get; set; }

        public QualityStandardController(IQualityStandardService aQualityStandardService)
        {
            QualityStandardService = aQualityStandardService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}