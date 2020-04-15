using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels
{
    public class OperationModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public OperationGroupModel Group { get; set; }
        public short? DefaultDueDays { get; set; }
        public bool ThicknessIsRequired { get; set; }
    }
}
