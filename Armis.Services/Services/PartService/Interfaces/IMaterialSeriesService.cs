﻿using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.PartService.Interfaces
{
    public interface IMaterialSeriesService
    {
        Task<IEnumerable<MaterialSeriesModel>> GetAllMaterialSeries();
    }
}
