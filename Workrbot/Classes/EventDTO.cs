using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workrbot.Enums;

namespace Workrbot.Classes
{
    public class EventDTO
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public bool TagUser { get; set; }
        public string Comment { get; set; }
        public EventTrigger EventTrigger { get; set; }
        public SecondaryTrigger SecondaryTrigger { get; set; }
        public string SecondaryTriggerActionValue { get; set; }
        public WorkItemActionField? WorkItemActionField { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public string Project { get; set; }

        public EventDTO()
        {
            EventId = Guid.NewGuid();
        }
       
    }
}