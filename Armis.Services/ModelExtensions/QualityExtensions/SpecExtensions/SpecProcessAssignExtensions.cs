using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.PartExtensions;
using Armis.DataLogic.ModelExtensions.QualityExtensions.ProcessExtensions;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SpecProcessAssignExtensions
    {
        //To Model(s)
        public static SpecProcessAssignModel ToModel(this SpecProcessAssign aSpecProcessAssignEntity)
        {
            return new SpecProcessAssignModel()
            {
                SpecId = aSpecProcessAssignEntity.SpecId,
                SpecRevId = aSpecProcessAssignEntity.SpecRevId,
                SpecAssignId = aSpecProcessAssignEntity.SpecAssignId,
                CustomerId = aSpecProcessAssignEntity.Customer,
                ProcessId = aSpecProcessAssignEntity.ProcessId,
                ProcessRevId = aSpecProcessAssignEntity.ProcessRevId,
                Inactive = aSpecProcessAssignEntity.Inactive,
                IsReviewNeeded = aSpecProcessAssignEntity.ReviewNeeded
            };
        }

        public static IEnumerable<SpecProcessAssignModel> ToModels(this IEnumerable<SpecProcessAssign> aSpecProcessAssigns)
        {
            var theResultingModels = new List<SpecProcessAssignModel>();

            foreach (var specProcessAssign in aSpecProcessAssigns)
            {
                theResultingModels.Add(specProcessAssign.ToModel());
            }

            return theResultingModels;
        }

        public static SpecProcessAssignModel ToHydratedModel(this SpecProcessAssign aSpecProcessAssignEntity)
        {
            return new SpecProcessAssignModel()
            {
                SpecId = aSpecProcessAssignEntity.SpecId,
                SpecRevId = aSpecProcessAssignEntity.SpecRevId,
                SpecAssignId = aSpecProcessAssignEntity.SpecAssignId,
                CustomerId = aSpecProcessAssignEntity.Customer,
                ProcessId = aSpecProcessAssignEntity.ProcessId,
                ProcessRevId = aSpecProcessAssignEntity.ProcessRevId,
                Inactive = aSpecProcessAssignEntity.Inactive,
                IsReviewNeeded = aSpecProcessAssignEntity.ReviewNeeded,
                ProcessRevision = aSpecProcessAssignEntity.Process.ToModel(aSpecProcessAssignEntity.Process.Process.Name),
                Customer = (aSpecProcessAssignEntity.CustomerNavigation != null) ? aSpecProcessAssignEntity.CustomerNavigation.ToModel() : null,
                SpecificationRevision = aSpecProcessAssignEntity.Spec.ToHydratedModel(),
                SpecProcessAssignOptionModels = (aSpecProcessAssignEntity.SpecProcessAssignOption != null && aSpecProcessAssignEntity.SpecProcessAssignOption.Any()) ? aSpecProcessAssignEntity.SpecProcessAssignOption.ToHydratedModels().ToList() : null
            };
        }

        public static IEnumerable<SpecProcessAssignModel> ToHydratedModels(this IEnumerable<SpecProcessAssign> aSpecProcessAssignEntities)
        {
            var theResultingModels = new List<SpecProcessAssignModel>();

            foreach (var entity in aSpecProcessAssignEntities)
            {
                theResultingModels.Add(entity.ToHydratedModel());
            }

            return theResultingModels;
        }

        //To Entity
        public static SpecProcessAssign ToEntity(this SpecProcessAssignModel aSpecProcessAssignModel)
        {
            return new SpecProcessAssign()
            {
                SpecId = aSpecProcessAssignModel.SpecId,
                SpecRevId = aSpecProcessAssignModel.SpecRevId,
                SpecAssignId = aSpecProcessAssignModel.SpecAssignId,
                Customer = aSpecProcessAssignModel.CustomerId,
                ProcessId = aSpecProcessAssignModel.ProcessId,
                ProcessRevId = aSpecProcessAssignModel.ProcessRevId,
                Inactive = aSpecProcessAssignModel.Inactive,
                ReviewNeeded = aSpecProcessAssignModel.IsReviewNeeded,
                SpecProcessAssignOption = (aSpecProcessAssignModel.SpecProcessAssignOptionModels != null)? aSpecProcessAssignModel.SpecProcessAssignOptionModels.ToEntities().ToList() : null
            };
        }

        /// <summary>
        /// Turns a SpecProcessAssign into an entity along with all the options, but the options are NOT hydrated. 
        /// </summary>
        public static SpecProcessAssign ToHydratedEntity(this SpecProcessAssignModel aSpecProcessAssignModel)
        {
            var result = aSpecProcessAssignModel.ToEntity();
            result.SpecProcessAssignOption = aSpecProcessAssignModel.SpecProcessAssignOptionModels.ToEntities().ToList();

            return result;
        }
    }
}
