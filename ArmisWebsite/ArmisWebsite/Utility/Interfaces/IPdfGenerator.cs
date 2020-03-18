using Armis.BusinessModels.ProcessModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArmisWebsite.Utility.Interfaces
{
    public interface IPdfGenerator
    {
        string GenerateRouterPdf(ProcessModel aProcessModel, ProcessRevisionModel aRevisionModel);
    }
}
