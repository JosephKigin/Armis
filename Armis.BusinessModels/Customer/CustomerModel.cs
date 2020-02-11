using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.Customer
{
    public class CustomerModel
    {
        //TODO: This class was first created for a process creation screen and will need to be expanded upon later.
        public int Id { get; set; }
        public string SearchName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; } //TODO: switch this to non-nullable when the database is updated.
    }
}
