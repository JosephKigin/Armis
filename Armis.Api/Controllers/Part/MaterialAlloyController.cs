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
    public class MaterialAlloyController : ControllerBase
    {
        private readonly ILogger<MaterialAlloyController> _logger;

        public IMaterialAlloyService MaterialAlloyService { get; set; }

        public MaterialAlloyController(IMaterialAlloyService aMaterialAlloyService, ILogger<MaterialAlloyController> aLogger)
        {
            MaterialAlloyService = aMaterialAlloyService;
            _logger = aLogger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialAlloyModel>>> GetAllMaterialAlloys()
        {
            try
            {
                var data = await MaterialAlloyService.GetAllMaterialAlloys();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("MaterialAlloyController.GetAllMaterialAlloys() Not able to get all material alloys. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MaterialAlloyModel>> CreateMaterialAlloy(MaterialAlloyModel aMaterialAlloyModel)
        {
            try
            {
                var data = await MaterialAlloyService.CreateMaterialAlloy(aMaterialAlloyModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("MaterialAlloyController.CreateMaterialAlloy(MaterialAlloyModel aMaterialAlloyModel) Not able to create material alloy ({materialAlloyModel}). | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aMaterialAlloyModel), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}