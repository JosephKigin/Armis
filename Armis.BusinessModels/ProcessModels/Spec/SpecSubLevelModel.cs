using System.Collections.Generic;

namespace Armis.BusinessModels.ProcessModels.Spec
{
    public class SpecSubLevelModel
    {
        public int SpecId { get; set; }
        public int InternalRev { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int LevelSeq { get; set; }
        public byte? DefaultChoice { get; set; }
        public IEnumerable<SpecSubLevelChoiceModel> Choices { get; set; }
    }
}
