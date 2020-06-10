using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ARExtensions;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using Armis.DataLogic.ModelExtensions.EmployeeExtensions;
using Armis.DataLogic.ModelExtensions.QualityExtensions.InspectionExtensions;
using Armis.DataLogic.ModelExtensions.QualityExtensions.SpecExtensions;
using Armis.DataLogic.ModelExtensions.ShippingExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.DataLogic.ModelExtensions.OrderEntryExtensions
{
    public static class OrderHeadExtensions
    {
        public static OrderHeadModel ToModel(this OrderHead anOrderHeadEntity)
        {
            return new OrderHeadModel()
            {
                OrderId = anOrderHeadEntity.OrderId,
                CustId = anOrderHeadEntity.CustId,
                Ponum = anOrderHeadEntity.Ponum,
                OrderDate = anOrderHeadEntity.OrderDate,
                DueDate = anOrderHeadEntity.DueDate,
                ShipDate = anOrderHeadEntity.ShipDate,
                ShipTime = anOrderHeadEntity.ShipTime,
                ReqDate = anOrderHeadEntity.ReqDate,
                DoneDate = anOrderHeadEntity.DoneDate,
                DoneTime = anOrderHeadEntity.DoneTime,
                TargetDate = anOrderHeadEntity.TargetDate,
                PriceStatusId = anOrderHeadEntity.PriceStatusId,
                IsPriceHold = anOrderHeadEntity.IsPriceHold,
                IsBadJob = anOrderHeadEntity.IsBadJob,
                IsJobHold = anOrderHeadEntity.IsJobHold,
                JobHoldToEmp = anOrderHeadEntity.JobHoldToEmp,
                JobHoldByEmp = anOrderHeadEntity.JobHoldByEmp,
                QualStdId = anOrderHeadEntity.QualStdId,
                CertChargeId = anOrderHeadEntity.CertChargeId,
                LastCompleteRemSentDt = anOrderHeadEntity.LastCompleteRemSentDt,
                SuppressCompNotify = anOrderHeadEntity.SuppressCompNotify,
                PackageId = anOrderHeadEntity.PackageId,
                SpecId = anOrderHeadEntity.SpecId,
                SpecRevId = anOrderHeadEntity.SpecRevId,
                SpecAssignId = anOrderHeadEntity.SpecAssignId,
                ShipViaId = anOrderHeadEntity.ShipViaId,
                IsReturnAsIs = anOrderHeadEntity.IsReturnAsIs,
                CreditAuthByEmp = anOrderHeadEntity.CreditAuthByEmp,
                LotChargeTotal = anOrderHeadEntity.LotChargeTotal,
                CertChargeTotal = anOrderHeadEntity.CertChargeTotal,
                SubTotal = anOrderHeadEntity.SubTotal,
                ShipChargeId = anOrderHeadEntity.ShipChargeId,
                HandlingChargeId = anOrderHeadEntity.HandlingChargeId,
                MiscChargeId = anOrderHeadEntity.MiscChargeId,
                ExpediteStatus = anOrderHeadEntity.ExpediteStatus
            };
        }

        public static IEnumerable<OrderHeadModel> ToModels(this IEnumerable<OrderHead> anOrderHeadEntities)
        {
            var result = new List<OrderHeadModel>();

            foreach (var entity in anOrderHeadEntities)
            {
                result.Add(entity.ToModel());
            }

            return result;
        }

        public static OrderHeadModel ToHydratedModel(this OrderHead anOrderHeadEntity)
        {
            var result = anOrderHeadEntity.ToModel();
            result.CertCharge = (anOrderHeadEntity.CertCharge != null)? anOrderHeadEntity.CertCharge.ToModel() : null;
            result.CreditAuthByEmployee = (anOrderHeadEntity.CreditAuthByEmpNavigation != null)? anOrderHeadEntity.CreditAuthByEmpNavigation.ToModel() : null;
            result.Customer = (anOrderHeadEntity.Cust != null)? anOrderHeadEntity.Cust.ToModel() : null;
            result.HandlingCharge = (anOrderHeadEntity.HandlingCharge != null)? anOrderHeadEntity.HandlingCharge.ToModel() : null;
            result.IsInspected = anOrderHeadEntity.IsInspectedNavigation.ToModel(); 
            result.IsMaskingNotify = anOrderHeadEntity.IsMaskingNotifyNavigation.ToModel();
            result.IsPrePrice = anOrderHeadEntity.IsPrePriceNavigation.ToModel();
            result.IsPriceApproval = anOrderHeadEntity.IsPriceApprovalNavigation.ToModel();
            result.JobHoldByEmployee = (anOrderHeadEntity.JobHoldByEmpNavigation != null)? anOrderHeadEntity.JobHoldByEmpNavigation.ToModel() : null;
            result.JobHoldToEmployee = (anOrderHeadEntity.JobHoldToEmpNavigation != null)? anOrderHeadEntity.JobHoldToEmpNavigation.ToModel() : null;
            result.MiscCharge = (anOrderHeadEntity.MiscCharge != null)? anOrderHeadEntity.MiscCharge.ToModel() : null;
            result.Package = (anOrderHeadEntity.Package != null)? anOrderHeadEntity.Package.ToModel() : null;
            result.PriceStatus = anOrderHeadEntity.PriceStatus.ToModel(); 
            result.QualityStandard = (anOrderHeadEntity.QualStd != null)? anOrderHeadEntity.QualStd.ToModel() : null;
            result.ShipCharge = (anOrderHeadEntity.ShipCharge != null)? anOrderHeadEntity.ShipCharge.ToModel() : null;
            result.ShipVia = (anOrderHeadEntity.ShipVia != null)? anOrderHeadEntity.ShipVia.ToModel() : null;
            result.Spec = anOrderHeadEntity.Spec.ToHydratedModel(); //Spec will be hydrated because much of the information is needed when an OrderHead is pulled.
            result.OrderComment = (anOrderHeadEntity.OrderComment != null)? anOrderHeadEntity.OrderComment.ToModel() : null; 
            result.OrderExpedite = (anOrderHeadEntity.OrderExpediteOrder != null)? anOrderHeadEntity.OrderExpediteOrder.ToModel() : null;
            result.OrderShipToOverride = (anOrderHeadEntity.OrderShipToOverride != null)? anOrderHeadEntity.OrderShipToOverride.ToModel() : null;
            result.OrderDetails = anOrderHeadEntity.OrderDetail.ToModels();

            return result;
        }

        public static IEnumerable<OrderHeadModel> ToHydratedModels(this IEnumerable<OrderHead> anOrderHeadEntities)
        {
            var result = new List<OrderHeadModel>();

            foreach (var entity in anOrderHeadEntities)
            {
                result.Add(entity.ToHydratedModel());
            }

            return result;
        }
    }
}
