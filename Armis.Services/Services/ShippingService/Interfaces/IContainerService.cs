﻿using Armis.BusinessModels.ShippingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.ShippingService.Interfaces
{
    public interface IContainerService
    {
        Task<IEnumerable<ContainerModel>> GetAllContainers();
    }
}
