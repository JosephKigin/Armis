using System.Collections.Generic;

namespace Armis.BusinessModels.ProcessModels.Spec
{
    public class SpecSubLevelModel
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public byte LevelSeq { get; set; }
        public byte? DefaultChoice { get; set; }
        public IEnumerable<SpecSubLevelChoiceModel> Choices { get; set; }
    }
}
