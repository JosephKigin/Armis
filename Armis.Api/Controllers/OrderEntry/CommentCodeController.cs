using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.OrderEntryModels;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers.OrderEntry
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentCodeController : ControllerBase
    {
        public ICommentCodeService CommentCodeService { get; set; }

        public CommentCodeController(ICommentCodeService aCommentCodeService)
        {
            CommentCodeService = aCommentCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentCodeModel>>> GetAllCommentCode()
        {
            try
            {
                var data = await CommentCodeService.GetAllCommentCodes();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}