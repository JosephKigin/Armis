using Armis.BusinessModels.QualityModels.Process;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions
{
    public static class OperationExtensions
    {
        public static OperationModel ToModel(this Operation anOperation)
        {
            return new OperationModel()
            {
                Name = anOperation.Name,
                OperShortName = anOperation.OperShortName,
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
                OperShortName = anOperationModel.OperShortName,
                Name = anOperationModel.Name,
                DefaultDueDays = anOperationModel.DefaultDueDays,
                ThicknessIsRequired = anOperationModel.ThicknessIsRequired,
                OperGroup = anOperationModel.Group.ToEntity()
            };
        }
    }
}
