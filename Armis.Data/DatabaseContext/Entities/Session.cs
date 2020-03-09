using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public string Status { get; set; }
        public short? LoginArea { get; set; }
        public short? LoginDept { get; set; }
        public short? EmployeeId { get; set; }
        public DateTime? SignInDate { get; set; }
        public TimeSpan? SignInTime { get; set; }
        public bool? IsUsedHelper { get; set; }
        public DateTime? SignOutDate { get; set; }
        public TimeSpan? SignOutTime { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Area LoginAreaNavigation { get; set; }
        public virtual Department LoginDeptNavigation { get; set; }
        public virtual Status StatusNavigation { get; set; }
    }
}
