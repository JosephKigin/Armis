using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Armis.DataLogic.ModelExtensions.ProcessExtensions;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class OperationExtensions
    {
        public static OperationModel ToModel(this Operation anOperation)
        {
            return new OperationModel()
            {
                Name = anOperation.Name,
                Code = anOperation.OperationCd,
                Id = anOperation.OperationId,
                Group = anOperation.OperGroup.ToModel(),
                DefaultDueDays = anOperation.DefaultDueDays,
                ThicknessIsRequired = anOperation.ThicknessIsRequired
            };
        }

        public static IEnumerable<OperationModel> ToModels(this IEnumerable<Operation> anOperationList)
        {
            var result = new List<OperationModel>();

            foreach (var operation in anOperationList)
            {
                result.Add(operation.ToModel());
            }

            return result;
        }

        public static Operation ToEntity(this OperationModel anOperationModel)
        {
            return new Operation()
            {
                OperationId = anOperationModel.Id,
                OperationCd = anOperationModel.Code,
                Name = anOperationModel.Name,
                DefaultDueDays = anOperationModel.DefaultDueDays,
                ThicknessIsRequired = anOperationModel.ThicknessIsRequired,
                OperGroup = anOperationModel.Group.ToEntity()
            };
        }
    }
}
