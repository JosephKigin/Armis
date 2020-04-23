using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.QualityModels.Spec;
using Armis.DataLogic.Services.QualityServices.Inspection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.Quality.Inspection
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InspectTestTypeController : ControllerBase
    {
        public IInspectTestTypeService InspectTestTypeService { get; set; }

        public InspectTestTypeController(IInspectTestTypeService anInspectTestTypeService)
        {
            InspectTestTypeService = anInspectTestTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectTestTypeModel>>> GetAll()
        {
            try
            {
                var data = await InspectTestTypeService.GetAllInspectTestType();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<InspectTestTypeModel>> CreateInspectionTestType(InspectTestTypeModel anInspectTestTypeModel)
        {
            try
            {
                var data = await InspectTestTypeService.CreateInspectTestType(anInspectTestTypeModel);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}