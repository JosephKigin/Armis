using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Armis.Core.Models.Process.RevModels
{
    public class SubOperationRevModel
    {
        public SubOperationRevModel()
        {
            Steps = new Collection<StepModel>();
        }

        public SubOperationModel OriginalSubOp { get; set; }
        public int RevId { get; set; }
        public int CreatedByEmp { get; set; } //TODO: should this be an employee model or an Id?
        public DateTime DateCreated { get; set; }
        public DateTime TimeCreated { get; set; } //TODO: More specific types or combine these?
        public string Comments { get; set; }
        public string Status { get; set; }
        //TODO: oqienrcoiqnerpivnbapivjbad;kijvnas;kljna;isjnbxiwbfciqebfr qenfajsdnvc;akjbdv;kasjhbdc;kasjndc;kasnjviobnqetriu SubOpStepModel? How is this going to work?
        public ICollection<StepModel> Steps { get; set; }
    }
}
