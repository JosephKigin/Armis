﻿using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Department
    {
        public Department()
        {
            DeptArea = new HashSet<DeptArea>();
            DeptOperation = new HashSet<DeptOperation>();
            DeptSpec = new HashSet<DeptSpec>();
            Memo = new HashSet<Memo>();
            OprLoadPrice = new HashSet<OprLoadPrice>();
            OprMaterialPrice = new HashSet<OprMaterialPrice>();
            OprThickPrice = new HashSet<OprThickPrice>();
            OrderExpedite = new HashSet<OrderExpedite>();
            Part = new HashSet<Part>();
            PlateResult = new HashSet<PlateResult>();
            ProcessLoad = new HashSet<ProcessLoad>();
            Session = new HashSet<Session>();
        }

        public short DepartmentId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsShownOnShopList { get; set; }
        public decimal PlaterBurRate { get; set; }
        public decimal HelperBurRate { get; set; }
        public decimal ReworkBurRate { get; set; }
        public string DeptTypeCd { get; set; }
        public short? ScheduleAreaId { get; set; }
        public decimal? LeadTime { get; set; }
        public string LoadTypeCd { get; set; }

        public virtual DeptTypeCode DeptTypeCdNavigation { get; set; }
        public virtual LoadType LoadTypeCdNavigation { get; set; }
        public virtual Area ScheduleArea { get; set; }
        public virtual ICollection<DeptArea> DeptArea { get; set; }
        public virtual ICollection<DeptOperation> DeptOperation { get; set; }
        public virtual ICollection<DeptSpec> DeptSpec { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<OprLoadPrice> OprLoadPrice { get; set; }
        public virtual ICollection<OprMaterialPrice> OprMaterialPrice { get; set; }
        public virtual ICollection<OprThickPrice> OprThickPrice { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpedite { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<ProcessLoad> ProcessLoad { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
