﻿using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.QualityServices.Inspection.Interfaces
{
    public interface ISamplePlanService
    {
        Task<IEnumerable<SamplePlanModel>> GetAllSamplePlans(); 
        Task<IEnumerable<SamplePlanModel>> GetAllHydratedSamplePlans();
    }
}