using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workrbot.Classes
{
    public enum ClosedReasonEnum
    {
        [Description("Fixed and Verified")]
        FixedAndVerified,

        [Description("As Designed")]
        AsDesigned,

        [Description("Cannot Reproduce")]
        CannotReproduce,

        [Description("Copied To Backlog")]
        CopiedToBacklog,

        [Description("Deferred")]
        Deferred,

        [Description("Duplicate")]
        Duplicate,

        [Description("Obsolete")]
        Obsolete,

        [Description("Fixed")]
        Fixed,
    }
}