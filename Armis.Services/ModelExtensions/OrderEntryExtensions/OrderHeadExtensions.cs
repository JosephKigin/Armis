using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext.Entities;
using Armis.DataLogic.ModelExtensions.ARExtensions;
using Armis.DataLogic.ModelExtensions.CustomerExtensions;
using Armis.DataLogic.ModelExtensions.EmployeeExtensions;
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
                SubTotal = anOrderHeadEntity.SubTotal,
                ExpediteStatus = anOrderHeadEntity.ExpediteStatus,
                IsNadcap = anOrderHeadEntity.IsNadCap,
                ReworkFromOrder = anOrderHeadEntity.ReworkFromOrder,
                ReworkDeptId = anOrderHeadEntity.ReworkDeptId
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
            result.IsInspected = anOrderHeadEntity.IsInspectedNavigation.ToModel(); 
            result.IsMaskingNotify = anOrderHeadEntity.IsMaskingNotifyNavigation.TernaryCodeId;
            result.IsPrePrice = anOrderHeadEntity.IsPrePriceNavigation.ToModel();
            result.IsPriceApproval = anOrderHeadEntity.IsPriceApprovalNavigation.ToModel();
            result.JobHoldByEmployee = (anOrderHeadEntity.JobHoldByEmpNavigation != null)? anOrderHeadEntity.JobHoldByEmpNavigation.ToModel() : null;
            result.JobHoldToEmployee = (anOrderHeadEntity.JobHoldToEmpNavigation != null)? anOrderHeadEntity.JobHoldToEmpNavigation.ToModel() : null;
            result.Package = (anOrderHeadEntity.Package != null)? anOrderHeadEntity.Package.ToModel() : null;
            result.PriceStatus = anOrderHeadEntity.PriceStatus.ToModel();
            result.ShipVia = (anOrderHeadEntity.ShipVia != null)? anOrderHeadEntity.ShipVia.ToModel() : null;
            result.Spec = anOrderHeadEntity.Spec.ToHydratedModel(); //Spec will be hydrated because much of the information is needed when an OrderHead is pulled.
            result.OrderComment = (anOrderHeadEntity.OrderComment != null)? anOrderHeadEntity.OrderComment.ToModel() : null;
            result.OrderShipToOverride = (anOrderHeadEntity.OrderShipToOverride != null)? anOrderHeadEntity.OrderShipToOverride.ToModel() : null;
            result.OrderReceiveds = anOrderHeadEntity.OrderReceived.ToHydratedModels(); 
            result.OrderDetails = anOrderHeadEntity.OrderDetail.ToHydratedModels();

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

        public static OrderHead ToEntity(this OrderHeadModel anOrderHeadModel)
        {
            return new OrderHead()
            {
                CustId = anOrderHeadModel.CustId,
                Ponum = anOrderHeadModel.Ponum,
                OrderDate = anOrderHeadModel.OrderDate,
                DueDate = anOrderHeadModel.DueDate,
                ShipDate = anOrderHeadModel.ShipDate,
                ShipTime = anOrderHeadModel.ShipTime,
                ReqDate = anOrderHeadModel.ReqDate,
                DoneDate = anOrderHeadModel.DoneDate,
                TargetDate = anOrderHeadModel.TargetDate,
                PriceStatusId = anOrderHeadModel.PriceStatusId,
                IsPriceHold = anOrderHeadModel.IsPriceHold,
                IsBadJob = anOrderHeadModel.IsBadJob,
                IsJobHold = anOrderHeadModel.IsJobHold,
                JobHoldToEmp = anOrderHeadModel.JobHoldToEmp,
                JobHoldByEmp = anOrderHeadModel.JobHoldByEmp,
                CertChargeId = anOrderHeadModel.CertChargeId,
                LastCompleteRemSentDt = anOrderHeadModel.LastCompleteRemSentDt,
                SuppressCompNotify = anOrderHeadModel.SuppressCompNotify,
                IsMaskingNotify = anOrderHeadModel.IsMaskingNotify,
                PackageId = anOrderHeadModel.PackageId,
                SpecId = anOrderHeadModel.SpecId,
                SpecRevId = anOrderHeadModel.SpecRevId,
                SpecAssignId = anOrderHeadModel.SpecAssignId,
                ShipViaId = anOrderHeadModel.ShipViaId,
                IsPriceApproval = anOrderHeadModel.IsPriceApproval.TernaryCodeId,
                IsReturnAsIs = anOrderHeadModel.IsReturnAsIs,
                IsPrePrice = anOrderHeadModel.IsPrePrice.TernaryCodeId,
                CreditAuthByEmp = anOrderHeadModel.CreditAuthByEmp,
                IsInspected = anOrderHeadModel.IsInspected.TernaryCodeId,
                SubTotal = anOrderHeadModel.SubTotal,
                ExpediteStatus = anOrderHeadModel.ExpediteStatus,
                IsNadCap = anOrderHeadModel.IsNadcap,
                ReworkFromOrder = anOrderHeadModel.ReworkFromOrder,
                ReworkDeptId = anOrderHeadModel.ReworkDeptId
            };
        }
    }
}
