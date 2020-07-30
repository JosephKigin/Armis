using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.EmployeeExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.PartExtensions
{
    public static class PartExtensions
    {
        public static PartModel ToModel(this Part aPartEntity)
        {
            return new PartModel()
            {
                PartId = aPartEntity.PartId,
                PartName = aPartEntity.PartName,
                Inactive = aPartEntity.Inactive,
                ExternalRev = aPartEntity.ExternalRev,
                Description = aPartEntity.Description,
                Dimensions = aPartEntity.Dimensions,
                RackId = aPartEntity.RackId,
                SurfaceArea = aPartEntity.SurfaceArea,
                SauoM = aPartEntity.SauoM,
                PieceWeight = aPartEntity.PieceWeight,
                StandardDeptId = aPartEntity.StandardDept,
                Bake = aPartEntity.Bake,
                BasePrice = aPartEntity.BasePrice,
                MinLotCharge = aPartEntity.MinLotCharge,
                PartsPerLoad = aPartEntity.PartsPerLoad,
                MaskPcsPerHour = aPartEntity.MaskPcsPerHour,
                NotifyWhenMasking = aPartEntity.NotifyWhenMasking,
                AlloyId = aPartEntity.Alloy,
                SeriesId = aPartEntity.SeriesId,
                CreatedByEmpId = aPartEntity.CreatedByEmp,
                DateCreated = aPartEntity.DateCreated,
                TimeCreated = aPartEntity.TimeCreated
            };
        }

        public static IEnumerable<PartModel> ToModels(this IEnumerable<Part> aPartEntities)
        {
            var result = new List<PartModel>();
            
            foreach (var partEntity in aPartEntities)
            {
                result.Add(partEntity.ToModel());
            }

            return result;
        }

        public static PartModel ToHydratedModel(this Part aPartEntity)
        {
            var result = aPartEntity.ToModel();
            result.Alloy = aPartEntity.AlloyNavigation.ToModel();
            result.CreatedByEmp = aPartEntity.CreatedByEmpNavigation.ToModel();
            result.Series = aPartEntity.Series.ToModel();
            //result.StandardDept = aPartEntity.StandardDept.ToModel(); TODO: Standard Dept doesn't have extensions yet

            return result;
        }

        public static IEnumerable<PartModel> ToHydratedModels(this IEnumerable<Part> aPartEntities)
        {
            var result = new List<PartModel>();

            foreach (var partEntity in aPartEntities)
            {
                result.Add(partEntity.ToHydratedModel());
            }

            return result;
        }
    }
}
