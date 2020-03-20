using Armis.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armis.Api
{
    public class Index
    {
        public string DatabaseState { get; set; }

        public Index(string dbState)
        {
            DatabaseState = dbState;
        }
    }
}
