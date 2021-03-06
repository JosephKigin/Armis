﻿using Armis.BusinessModels.PartModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArmisWebsite.DataAccess.Part.Interfaces
{
    public interface IUoMDataAccess
    {
        Task<IEnumerable<UnitOfMeasureModel>> GetAllUoMs();
    }
}
