using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class PackageCodeExtensions
    {
        public static PackageCodeModel ToModel(this PackageCode aPackageCodeEntity)
        {
            return new PackageCodeModel()
            {
                PackageId = aPackageCodeEntity.PackageId,
                PackageCd = aPackageCodeEntity.PackageCd,
                Description = aPackageCodeEntity.Description,
                AddOnPercent = aPackageCodeEntity.AddOnPercent
            };
        }

        public static IEnumerable<PackageCodeModel> ToModels(this IEnumerable<PackageCode> aPackageCodeEntities)
        {
            var result = new List<PackageCodeModel>();

            foreach (var entity in aPackageCodeEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
