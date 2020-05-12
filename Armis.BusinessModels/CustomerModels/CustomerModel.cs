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
        public string StatusCode { get; set; } //TODO: This will be a  full model in the future when creating a customer is necessary, but it is not as of now.
        public DateTime? CreatedDate { get; set; } 
    }
}
