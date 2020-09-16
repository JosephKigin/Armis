using Armis.BusinessModels.PartModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.EmployeeExtensions;
using Armis.DataLogic.ModelExtensions.ShopFloorExtensions.DepartmentExtensions;
using Armis.DataLogic.ModelExtensions.ShopFloorExtensions.InventoryExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

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
                SurfaceAreaUoMId = aPartEntity.SurfaceAreaUoM,
                PieceWeight = aPartEntity.PieceWeight,
                StandardDeptId = aPartEntity.StandardDept,
                Bake = aPartEntity.Bake,
                BasePrice = aPartEntity.BasePrice,
                MinLotCharge = aPartEntity.MinLotCharge,
                PartsPerLoad = aPartEntity.PartsPerLoad,
                MaskPcsPerHour = aPartEntity.MaskPcsPerHour,
                NotifyWhenMasking = aPartEntity.NotifyWhenMasking,
                MaterialAlloyId = aPartEntity.MaterialAlloyId,
                MaterialSeriesId = aPartEntity.MaterialSeriesId,
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
            result.CreatedByEmp = aPartEntity.CreatedByEmpNavigation.ToModel();
            result.Alloy = (aPartEntity.MaterialAlloy != null)? aPartEntity.MaterialAlloy.ToModel() : null;
            result.Series = (aPartEntity.MaterialSeries != null)? aPartEntity.MaterialSeries.ToModel() : null;
            result.StandardDept = (aPartEntity.StandardDeptNavigation != null)? aPartEntity.StandardDeptNavigation.ToModel() : null;
            result.SurfaceAreaUnitOfMeasure = (aPartEntity.SurfaceAreaUoMNavigation != null) ? aPartEntity.SurfaceAreaUoMNavigation.ToModel() : null;
            result.Rack = (aPartEntity.Rack != null) ? aPartEntity.Rack.ToModel() : null;

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

        public static Part ToEntity(this PartModel aPartModel)
        {
            return new Part()
            {
                PartName = aPartModel.PartName,
                Inactive = false,
                ExternalRev = aPartModel.ExternalRev,
                Description = aPartModel.Description,
                Dimensions = aPartModel.Dimensions,
                RackId = aPartModel.RackId,
                SurfaceArea = aPartModel.SurfaceArea,
                SurfaceAreaUoM = aPartModel.SurfaceAreaUoMId,
                PieceWeight = aPartModel.PieceWeight,
                StandardDept = aPartModel.StandardDeptId,
                Bake = aPartModel.Bake,
                BasePrice = aPartModel.BasePrice,
                MinLotCharge = aPartModel.MinLotCharge,
                PartsPerLoad = aPartModel.PartsPerLoad,
                MaskPcsPerHour = aPartModel.MaskPcsPerHour,
                NotifyWhenMasking = aPartModel.NotifyWhenMasking,
                MaterialAlloyId = aPartModel.MaterialAlloyId,
                MaterialSeriesId = aPartModel.MaterialSeriesId,
                CreatedByEmp = aPartModel.CreatedByEmpId,
                DateCreated = DateTime.Now,
                TimeCreated = DateTime.Now.TimeOfDay
            };
        }
    }
}
