using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workrbot.Enums;

namespace Workrbot.Classes
{
    [Serializable]
    public class GraphItem
    {
        public string RepliedTo { get; set; }
        public DateTime TimeOfReply { get; set; }
        public EventTrigger TriggerType { get; set; }
    }
}