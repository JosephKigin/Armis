using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class ContactTitle
    {
        public ContactTitle()
        {
            Contact = new HashSet<Contact>();
        }

        public string ContactTitleCd { get; set; }
        public string TitleName { get; set; }
        public bool? Inactive { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
    }
}
