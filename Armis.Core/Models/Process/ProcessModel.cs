using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.Core.Models.Process
{
    public class ProcessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerId { get; set; } //This could be a customer model.  Will have to see in the future.  TODO: Customer Model??
    }
}
