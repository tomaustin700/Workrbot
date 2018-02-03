using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workrbot.Enums
{
    public enum WorkItemActionField : byte
    {
        Description = 0,
        [Display(Name = "Acceptance Criteria")]
        AcceptanceCriteria = 1,
        [Display(Name = "Repro Steps")]
        ReproSteps = 2,
        [Display(Name = "System Info")]
        SystemInfo = 3,
        [Display(Name = "Iteration Path")]
        IterationPath = 4,

    }
}