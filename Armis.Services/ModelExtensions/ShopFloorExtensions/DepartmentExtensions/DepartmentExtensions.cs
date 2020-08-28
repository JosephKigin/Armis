using Armis.BusinessModels.ShopFloorModels.Department;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShopFloorExtensions.DepartmentExtensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentModel ToModel(this Department aDeptEntity)
        {
            return new DepartmentModel()
            {
                DepartmentId = aDeptEntity.DepartmentId,
                Name = aDeptEntity.Name,
                ShortName = aDeptEntity.ShortName,
                IsShownOnShopList = aDeptEntity.IsShownOnShopList,
                PlaterBurRate = aDeptEntity.PlaterBurRate,
                HelperBurRate = aDeptEntity.HelperBurRate,
                ReworkBurRate = aDeptEntity.ReworkBurRate,
                ScheduleAreaId = aDeptEntity.ScheduleAreaId,
                LeadTime = aDeptEntity.LeadTime
            };
        }

        public static IEnumerable<DepartmentModel> ToModels(this IEnumerable<Department> aDeptEntities)
        {
            var result = new List<DepartmentModel>();

            foreach (var entity in aDeptEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
