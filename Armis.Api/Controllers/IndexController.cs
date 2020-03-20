using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armis.Data.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly ARMISContext context;

        public string DatabaseState { get; set; }

        public IndexController(ARMISContext aContext)
        {
            context = aContext;
            try
            {
                if (context.Database.CanConnect())
                {
                    DatabaseState = "Conntected";
                }
                else
                {
                    DatabaseState = "Not Connected";
                }
            }
            catch (Exception ex)
            {
                DatabaseState = "Not Connected " + ex.Message;
            }

        }

        [HttpGet]
        public Index Get()
        {
            return new Index(DatabaseState);
        }
    }
}