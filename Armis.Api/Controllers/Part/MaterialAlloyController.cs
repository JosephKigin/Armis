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
    public class MaterialAlloyController : ControllerBase
    {
        public IMaterialAlloyService MaterialAlloyService { get; set; }

        public MaterialAlloyController(IMaterialAlloyService aMaterialAlloyService)
        {
            MaterialAlloyService = aMaterialAlloyService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}