﻿using Armis.BusinessModels.QualityModels.InspectionModels;
using Armis.BusinessModels.QualityModels.Spec;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Quality.Inspection.Interfaces
{
    public interface ISamplePlanDataAccess
    {
        Task<SamplePlanModel> CreateNewSamplePlan(SamplePlanModel aSamplePlanModel);
        Task<IEnumerable<SamplePlanModel>> GetAllHydratedSamplePlans();
        Task<bool> CheckIfNameIsUnique(string aName);
    }
}
