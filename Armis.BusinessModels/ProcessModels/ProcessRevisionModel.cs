﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.ProcessModels
{
    public class ProcessRevisionModel
    {
        public string ProcessName { get; set; }
        public int ProcessId { get; set; }
        public int ProcessRevId { get; set; }
        public short CreatedByEmp { get; set; }
        public DateTime DateCreated { get; set; }
        public TimeSpan TimeCreated { get; set; }
        public string RevStatusCd { get; set; }
        public int? DueDays { get; set; }
        public string Comments { get; set; }

        public IEnumerable<StepModel> Steps { get; set; }
    }
}