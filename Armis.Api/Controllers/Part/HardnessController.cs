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
    public class HardnessController : ControllerBase
    {
        public IHardnessService HardnessService { get; set; }

        public HardnessController(IHardnessService aHardnessService)
        {
            HardnessService = aHardnessService;
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
                return BadRequest(ex.Message);
            }
        }
    }
}