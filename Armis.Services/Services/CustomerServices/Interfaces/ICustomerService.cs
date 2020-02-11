﻿using Armis.BusinessModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.CustomerServices.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
    }
}
