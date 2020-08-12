using System;
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
            OrderCommentStatic = new HashSet<OrderCommentStatic>();
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
        public byte DeptTypeId { get; set; }
        public short? ScheduleAreaId { get; set; }
        public decimal? LeadTime { get; set; }
        public byte? LoadTypeId { get; set; }

        public virtual DeptTypeCode DeptType { get; set; }
        public virtual LoadTypeCode LoadType { get; set; }
        public virtual Area ScheduleArea { get; set; }
        public virtual ICollection<DeptArea> DeptArea { get; set; }
        public virtual ICollection<DeptOperation> DeptOperation { get; set; }
        public virtual ICollection<DeptSpec> DeptSpec { get; set; }
        public virtual ICollection<Memo> Memo { get; set; }
        public virtual ICollection<OrderCommentStatic> OrderCommentStatic { get; set; }
        public virtual ICollection<OrderExpedite> OrderExpedite { get; set; }
        public virtual ICollection<Part> Part { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<ProcessLoad> ProcessLoad { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
