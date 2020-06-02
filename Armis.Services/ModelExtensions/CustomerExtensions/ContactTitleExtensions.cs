using Armis.BusinessModels.CustomerModels;
using Armis.Data.DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.CustomerExtensions
{
    public static class ContactTitleExtensions
    {
        public static ContactTitleModel ToModel(this ContactTitle aContactTitleEntity)
        {
            return new ContactTitleModel()
            {
                ContactTitleId = aContactTitleEntity.ContactTitleId,
                TitleName = aContactTitleEntity.TitleName,
                Inactive = aContactTitleEntity.Inactive
            };
        }

        public static IEnumerable<ContactTitleModel> ToModels(this IEnumerable<ContactTitle> aContactTitleEntities)
        {
            var result = new List<ContactTitleModel>();

            foreach (var entity in aContactTitleEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }
    }
}