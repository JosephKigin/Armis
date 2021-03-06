﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.BusinessModels.OrderEntryModels;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers.OrderEntry
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentCodeController : ControllerBase
    {
        private readonly ILogger<CommentCodeController> _logger;

        public ICommentCodeService CommentCodeService { get; set; }

        public CommentCodeController(ICommentCodeService aCommentCodeService, ILogger<CommentCodeController> aLogger)
        {
            CommentCodeService = aCommentCodeService;
            _logger = aLogger;
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
                _logger.LogError("CommentCodeController.GetAllCommentCodes() Not able to get all comment codes. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}