using Armis.BusinessModels.EmployeeModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.EmployeeExtensions
{
    public static class EmployeeModelExtensions
    {
        public static EmployeeModel ToModel(this Employee anEmployeeEntity)
        {
            return new EmployeeModel()
            {
                EmployeeId = anEmployeeEntity.EmpId,
                FirstName = anEmployeeEntity.FirstName,
                LastName = anEmployeeEntity.LastName,
                DefaultShift = anEmployeeEntity.DefaultShift,
                IsInactive = anEmployeeEntity.Inactive,
                IsPriceTraining = anEmployeeEntity.IsPriceTraining,
                IsShippingLogin = anEmployeeEntity.IsShippingLogin,
                EMail = anEmployeeEntity.EmailAddress,
                PhoneNum = anEmployeeEntity.PhoneNum,
                ExtUserId = anEmployeeEntity.ExtUserId,
                CanExpedite = anEmployeeEntity.CanExpedite,
                AreaId = anEmployeeEntity.AreaId
            };
        }
    }
}
