using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Area
    {
        public Area()
        {
            AreaRemark = new HashSet<AreaRemark>();
            Department = new HashSet<Department>();
            DeptArea = new HashSet<DeptArea>();
            Employee = new HashSet<Employee>();
            Location = new HashSet<Location>();
            PlateResult = new HashSet<PlateResult>();
            Rack = new HashSet<Rack>();
            Session = new HashSet<Session>();
        }

        public short AreaId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? AllowLogin { get; set; }
        public string DefaultLocation { get; set; }

        public virtual Location DefaultLocationNavigation { get; set; }
        public virtual DeptTypeCode TypeNavigation { get; set; }
        public virtual ICollection<AreaRemark> AreaRemark { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<DeptArea> DeptArea { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<PlateResult> PlateResult { get; set; }
        public virtual ICollection<Rack> Rack { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
