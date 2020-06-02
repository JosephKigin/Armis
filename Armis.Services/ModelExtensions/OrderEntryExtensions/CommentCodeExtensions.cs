using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class CommentCodeExtensions
    {
        public static CommentCodeModel ToModel(this CommentCode aCommentCodeEntity)
        {
            return new CommentCodeModel()
            {
                CommentId = aCommentCodeEntity.CommentId,
                CommentCode = aCommentCodeEntity.CommentCode1,
                CommentDesc = aCommentCodeEntity.CommentDesc,
                PriceIncPerc = aCommentCodeEntity.PriceIncPerc
            };
        }

        public static IEnumerable<CommentCodeModel> ToModels(this IEnumerable<CommentCode> aCommentCodeEntities)
        {
            var result = new List<CommentCodeModel>();

            foreach (var entity in aCommentCodeEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}
