using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.Part
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialSeriesController : ControllerBase
    {
        private readonly ILogger<MaterialSeriesController> _logger;

        public IMaterialSeriesService MaterialSeriesService { get; set; }

        public MaterialSeriesController(IMaterialSeriesService aMaterialSeriesService, ILogger<MaterialSeriesController> aLogger)
        {
            MaterialSeriesService = aMaterialSeriesService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialSeriesModel>>> GetAllMaterialSeries()
        {
            try
            {
                var data = await MaterialSeriesService.GetAllMaterialSeries();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("MaterialSeriesController.GetAllMaterialSeries() Not able to get all material series. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MaterialSeriesModel>> CreateMaterialSeries(MaterialSeriesModel aMaterialSeries)
        {
            try
            {
                var data = await MaterialSeriesService.CreateMaterialSeries(aMaterialSeries);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("MaterialSeriesController.CreateMaterialSeries(MaterialSeriesModel aMaterialSeries) Not able to create material series ({materialSeriesModel}). | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aMaterialSeries), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}