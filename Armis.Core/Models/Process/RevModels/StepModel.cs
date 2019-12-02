using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Armis.Core.Models.Process.RevModels
{
    public class StepModel
    {
        public StepModel()
        {
            Variables = new Collection<StepVariableModel>();
        }

        public int Id { get; set; }
        public string StepCategory { get; set; } //This will be a code in the Db that will need to be translated into the actual category using the StepCategory table.
        public string Status { get; set; }  //Same as the comment above except with the Status table
        public string Name { get; set; }
        public bool IsSignOfRequired { get; set; }
        public string Instructions { get; set; }
        public ICollection<StepVariableModel> Variables { get; set; }
    }
}
