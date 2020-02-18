using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
                Group = anOperation.OperGroup.Name,
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
    }
}
