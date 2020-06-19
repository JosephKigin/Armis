using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.PartModels;
using Armis.DataLogic.Services.PartServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.Part
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialSeriesController : ControllerBase
    {
        public IMaterialSeriesService MaterialSeriesService { get; set; }

        public MaterialSeriesController(IMaterialSeriesService aMaterialSeriesService)
        {
            MaterialSeriesService = aMaterialSeriesService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}