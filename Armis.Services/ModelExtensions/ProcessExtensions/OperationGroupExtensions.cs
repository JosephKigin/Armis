using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class OperationGroupExtensions
    {
        public static OperationGroupModel ToModel(this OperationGroup anOperationGroupEntity)
        {
            return new OperationGroupModel()
            {
                Id = anOperationGroupEntity.OperGroupId,
                Name = anOperationGroupEntity.Name
            };
        }

        public static IEnumerable<OperationGroupModel> ToModels(this IEnumerable<OperationGroup> anOperationGroupEntityList)
        {
            var result = new List<OperationGroupModel>();

            foreach (var operGroupEntity in anOperationGroupEntityList)
            {
                result.Add(operGroupEntity.ToModel());
            }

            return result;
        }

        public static OperationGroup ToEntity(this OperationGroupModel anOperationGroupModel)
        {
            return new OperationGroup()
            {
                OperGroupId = anOperationGroupModel.Id,
                Name = anOperationGroupModel.Name
            };
        }
    }
}
