using Armis.BusinessModels.ProcessModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.ProcessExtensions
{
    public static class SubOpExtensions
    {
        public static SubopRevisionModel ToHydratedModel(this SubOpRevision aSubOpRev, ProcessSubOprSeq aSeq, IEnumerable<StepModel> aSteps, string aName)
        {
            return new SubopRevisionModel()
            {
                SubOpName = aName,
                Comments = aSubOpRev.Comments,
                CreatedByEmp = aSubOpRev.CreatedByEmp,
                DateCreated = aSubOpRev.DateCreated,
                RevStatusCd = aSubOpRev.RevStatusCd,
                SubOpId = aSubOpRev.SubOpId,
                SubOpRevId = aSubOpRev.SubOpRevId,
                TimeCreated = aSubOpRev.TimeCreated,
                Steps = aSteps,
                Sequence = aSeq.SubOpSeq
            };
        }

        public static SubopRevisionModel ToModel(this SubOpRevision aSubOpRev)
        {
            return new SubopRevisionModel()
            {
                Comments = aSubOpRev.Comments,
                CreatedByEmp = aSubOpRev.CreatedByEmp,
                DateCreated = aSubOpRev.DateCreated,
                RevStatusCd = aSubOpRev.RevStatusCd,
                SubOpId = aSubOpRev.SubOpId,
                SubOpRevId = aSubOpRev.SubOpRevId,
                TimeCreated = aSubOpRev.TimeCreated
            };
        }

        public static SubOpRevision ToEntity(this SubopRevisionModel aModel)
        {
            return new SubOpRevision()
            {
                Comments = aModel.Comments,
                CreatedByEmp = aModel.CreatedByEmp,
                DateCreated = aModel.DateCreated,
                RevStatusCd = aModel.RevStatusCd,
                SubOpId = aModel.SubOpId,
                SubOpRevId = aModel.SubOpRevId,
                TimeCreated = aModel.TimeCreated
            };
        }

        public static SubopModel ToModel(this SubOperation aSubop)
        {
            var theModel = new SubopModel()
            {
                Name = aSubop.Name,
                SubOpId = aSubop.SubOpId
            };

            foreach (var rev in aSubop.SubOpRevision) { theModel.Revs.Add(rev.ToModel()); }

            return theModel;
        }

        public static SubOperation ToEntity(this SubopModel aModel)
        {
            return new SubOperation()
            {
                Name = aModel.Name,
                SubOpId = aModel.SubOpId
            };
        }

    }
}
