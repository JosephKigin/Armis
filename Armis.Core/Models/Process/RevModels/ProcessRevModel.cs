using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Armis.Core.Models.Process.RevModels
{
    public class ProcessRevModel
    {
        public ProcessRevModel()
        {
            SubOperationRevs = new Collection<SubOperationRevModel>();
        }

        public ProcessRevModel Process { get; set; }
        public int RevId { get; set; }
        public int Empoyee { get; set; } //TODO: employee model, or employee number?
        public DateTime DateCreated { get; set; }
        public DateTime TimeCreated { get; set; } //TODO: Combine these two or change the type?
        public string Status { get; set; }
        public int DueDays { get; set; }
        public string Notes { get; set; }
        public ICollection<SubOperationRevModel> SubOperationRevs { get; set; }
    }
}
