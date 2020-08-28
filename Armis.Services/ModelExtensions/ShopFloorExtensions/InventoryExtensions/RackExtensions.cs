using Armis.BusinessModels.ShopFloorModels.Inventory;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShopFloorExtensions.InventoryExtensions
{
    public static class RackExtensions
    {
        public static RackModel ToModel(this Rack aRackEntity)
        {
            return new RackModel()
            {
                RackId = aRackEntity.RackId,
                Description = aRackEntity.Description,
                Dimensions = aRackEntity.Dimensions,
                MaterialAlloyId = aRackEntity.MaterialAlloyId,
                AreaId = aRackEntity.AreaId,
                ExtensionQty = aRackEntity.ExtensionQty,
                Photo = aRackEntity.Photo,
                Notes = aRackEntity.Notes
            };
        }
    }
}
