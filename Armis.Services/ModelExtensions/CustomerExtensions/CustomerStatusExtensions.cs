using Armis.BusinessModels.CustomerModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.CustomerExtensions
{
    public static class CustomerStatusExtensions
    {
        public static CustomerStatusModel ToModel(this CustomerStatus aCustomerStatusEntity)
        {
            return new CustomerStatusModel()
            {
                StatusId = aCustomerStatusEntity.StatusId,
                Code = aCustomerStatusEntity.Code,
                Description = aCustomerStatusEntity.Description
            };
        }
    }
}
