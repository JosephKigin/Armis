using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.QualityModels.Process
{
    public class OperationModel
    {
        public int Id { get; set; }
        public string OperShortName { get; set; }
        public string Name { get; set; }
        public short? DefaultDueDays { get; set; }
        public bool ThicknessIsRequired { get; set; }
        public int OperationGroupId { get; set; }

        public OperationGroupModel Group { get; set; }
    }
}
