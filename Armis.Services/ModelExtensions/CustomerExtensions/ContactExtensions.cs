using Armis.BusinessModels.CustomerModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.CustomerExtensions
{
    public static class ContactExtensions
    {
        public static ContactModel ToModel(this Contact aContactEntity)
        {
            return new ContactModel()
            {
                ContactId = aContactEntity.ContactId,
                CustId = aContactEntity.CustId,
                ShipToId = aContactEntity.ShipToId,
                FirstName = aContactEntity.FirstName,
                LastName = aContactEntity.LastName,
                Address1 = aContactEntity.Address1,
                Address2 = aContactEntity.Address2,
                Address3 = aContactEntity.Address3,
                State = aContactEntity.State,
                Zip = aContactEntity.Zip,
                Country = aContactEntity.Country,
                EmailAddress = aContactEntity.EmailAddress,
                PhoneNum = aContactEntity.PhoneNum,
                FaxNum = aContactEntity.FaxNum,
                TitleId = aContactEntity.TitleId,
                Inactive = aContactEntity.Inactive,
                Comments = aContactEntity.Comments
            };
        }

        public static IEnumerable<ContactModel> ToModels(this IEnumerable<Contact> aContactEntities)
        {
            var result = new List<ContactModel>();

            foreach (var entity in aContactEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static ContactModel ToHydratedModel(this Contact aContactEntity)
        {
            var result = aContactEntity.ToModel();
            result.ContactTitle = aContactEntity.Title.ToModel();
            result.ShipTo = aContactEntity.ShipTo.ToModel();

            return result;
        }

        public static IEnumerable<ContactModel> ToHydratedModels(this IEnumerable<Contact> aContactEntities)
        {
            var result = new List<ContactModel>();

            foreach (var entity in aContactEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }
    }
}
