using Armis.BusinessModels.QualityModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions
{
    public static class StepCategoryExtensions
    {
        //To Model
        public static StepCategoryModel ToModel(this StepCategory aStepCategoryEntity)
        {
            return new StepCategoryModel()
            {
                Name = aStepCategoryEntity.Name,
                Code = aStepCategoryEntity.StepCategoryCd,
                Type = aStepCategoryEntity.Type
            };
        }

        public static IEnumerable<StepCategoryModel> ToModels(this IEnumerable<StepCategory> aStepCategoryEntities)
        {
            var theModels = new List<StepCategoryModel>();

            foreach (var stepCategoryEntity in aStepCategoryEntities)
            {
                theModels.Add(stepCategoryEntity.ToModel());
            }

            return theModels;
        }

        //To Entity 
    }
}
