using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Armis.Data.DatabaseContext;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.Services.QualityServices;
using Armis.BusinessModels.QualityModels.Process;
using System.Text.Json;
using Armis.DataLogic.Services.QualityServices.Interfaces;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StepsController : ControllerBase
    { 
        private readonly ILogger<StepsController> _logger;

        public IStepService StepService { get; set; }


        public StepsController(IStepService aStepService, ILogger<StepsController> aLogger)
        {
            StepService = aStepService;
            _logger = aLogger;
        }

        // GET: api/Steps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StepModel>>> GetAllSteps()
        {
            try
            {
                var data = await StepService.GetAll();
                throw new Exception("Test break from API");
                return Ok(JsonSerializer.Serialize(data));
            }
            catch(Exception ex)
            {
                _logger.LogError("StepsController.GetAllSteps() Not able to get all steps. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StepCategoryModel>>> GetAllStepCategories()
        {
            try
            {
                var data = await StepService.GetAllStepCategories();

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("StepsController.GetAllStepCategories() Not able to get all step categories. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StepCategoryModel>> GetStepCategoryById(short id)
        {
            try
            {
                var data = await StepService.GetStepCategoryById(id);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("StepsController.GetStepCategoryById(short id) Not able to get step category for id {categoryId}. | Message: {exMessage} | StackTrace: {stackTrace}", id, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Steps/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Step>> GetStepById(int id)
        {
            try
            {
                var data = await StepService.GetStepById(id);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch(Exception ex)
            {
                _logger.LogError("StepsController.GetStepById(int id) Not able to get step for id {stepId}. | Message: {exMessage} | StackTrace: {stackTrace}", id, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        //GET: api/Steps/GetStepByName/zincplate
        [HttpGet("{stepName}")]
        public async Task<ActionResult<StepModel>> GetStepByName(string stepName)
        {
            try
            {
                var data = await StepService.GetStepByName(stepName);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("StepsController.GetStepByName(string stepName) Not able to get step for name {stepName}. | Message: {exMessage} | StackTrace: {stackTrace}", stepName, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{stepCategoryName}")]
        public async Task<ActionResult<IEnumerable<StepModel>>> GetAllStepsByCategory(string stepCategoryName)
        {
            try
            {
                var data = await StepService.GetAllByCategory(stepCategoryName);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("StepsController.GetAllStepsByCategory(string stepCategoryName) Not able to get step category for nanme {stepCategoryName}. | Message: {exMessage} | StackTrace: {stackTrace}", stepCategoryName, ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Steps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StepModel>> PostStep(StepModel aStep)
        {
            try
            {
                var data = await StepService.CreateStep(aStep);

                return Ok(JsonSerializer.Serialize(data));
            }
            catch (Exception ex)
            {
                _logger.LogError("StepsController.PostStep(StepModel aStep) Not able to create step {step}. | Message: {exMessage} | StackTrace: {stackTrace}", JsonSerializer.Serialize(aStep), ex.Message, ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }
    }
}