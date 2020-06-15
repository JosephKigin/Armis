using Armis.BusinessModels.ShippingModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ShippingExtensions
{
    public static class ContainerExtensions
    {
        public static ContainerModel ToModel(this Container aContainerEntity)
        {
            return new ContainerModel()
            {
                ContainerId = aContainerEntity.ContainerId,
                Code = aContainerEntity.Code,
                Description = aContainerEntity.Description
            };
        }

        public static IEnumerable<ContainerModel> ToModels(this IEnumerable<Container> aContainerEntities)
        {
            var result = new List<ContainerModel>();

            foreach (var entity in aContainerEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}