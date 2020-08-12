using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.Data.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly ARMISContext context;
        private readonly ILogger<IndexController> _logger;

        public string DatabaseState { get; set; }

        public IndexController(ARMISContext aContext, ILogger<IndexController> aLogger)
        {
            context = aContext;
            _logger = aLogger;

            try
            {
                if (context.Database.CanConnect())
                {
                    _logger.LogInformation("IndexController connected to the database successfully.");
                    DatabaseState = "Connected";
                }
                else
                {
                    _logger.LogError("IndexController couldn't connect to the database, but there was no exception.");
                    DatabaseState = "Not Connected";
                }
            }
            catch (Exception ex)
            {
                DatabaseState = "Not Connected " + ex.Message;
                _logger.LogError("IndexController threw an error while trying to connect to the database. | Message: {exMessage} | StackTrace: {stackTrace}", ex.Message, ex.StackTrace);
            }

        }

        [HttpGet]
        public Index Get()
        {
            return new Index(DatabaseState);
        }
    }
}