using Armis.BusinessModels.QualityModels.Spec;
using Armis.Data.DatabaseContext.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions
{
    public static class SpecProcessAssignOptionExtensions
    {
        //To Model(s)
        public static SpecProcessAssignOptionModel ToModel(this SpecProcessAssignOption anOptionEntity)
        {
            return new SpecProcessAssignOptionModel()
            {
                SpecId = anOptionEntity.SpecId,
                SpecRevId = anOptionEntity.SpecRevId,
                SpecAssignId = anOptionEntity.SpecAssignId,
                SubLevelSeqId = anOptionEntity.SubLevelSeqId,
                ChoiceSeqId = anOptionEntity.ChoiceSeqId
            };
        }

        public static IEnumerable<SpecProcessAssignOptionModel> ToModels(this IEnumerable<SpecProcessAssignOption> anOptionEntities)
        {
            var result = new List<SpecProcessAssignOptionModel>();

            foreach (var entity in anOptionEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static SpecProcessAssignOptionModel ToHydratedModel(this SpecProcessAssignOption anOptionEntity)
        {
            var result = anOptionEntity.ToModel();
            result.SpecChoice = anOptionEntity.SpecChoice.ToHydratedModel();

            return result;
        }

        public static IEnumerable<SpecProcessAssignOptionModel> ToHydratedModels(this IEnumerable<SpecProcessAssignOption> anOptionsEntities)
        {
            var result = new List<SpecProcessAssignOptionModel>();

            foreach (var entity in anOptionsEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }

        //To Entity(ies)
        public static SpecProcessAssignOption ToEntity(this SpecProcessAssignOptionModel aSpecProcessAssignOptionModel)
        {
            return new SpecProcessAssignOption()
            {
                SpecId = aSpecProcessAssignOptionModel.SpecId,
                SpecRevId = aSpecProcessAssignOptionModel.SpecRevId,
                SpecAssignId = aSpecProcessAssignOptionModel.SpecAssignId,
                SubLevelSeqId = aSpecProcessAssignOptionModel.SubLevelSeqId,
                ChoiceSeqId = aSpecProcessAssignOptionModel.ChoiceSeqId
            };
        }

        public static IEnumerable<SpecProcessAssignOption> ToEntities(this IEnumerable<SpecProcessAssignOptionModel> aSpecProcessAssignOptionModels)
        {
            var result = new List<SpecProcessAssignOption>();

            foreach (var model in aSpecProcessAssignOptionModels)
            {
                result.Add(model.ToEntity());
            }

            return result;
        }
    }
}
