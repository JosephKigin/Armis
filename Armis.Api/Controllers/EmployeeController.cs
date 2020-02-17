﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Armis.DataLogic.Services.ProcessServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService EmployeeService { get; set; }
        public EmployeeController(IEmployeeService anEmpService)
        {
            EmployeeService = anEmpService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> CheckIfEmployeeNumberExists(short id)
        {
            try
            {
                var data = await EmployeeService.CheckIfEmployeeNumberExists(id);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}