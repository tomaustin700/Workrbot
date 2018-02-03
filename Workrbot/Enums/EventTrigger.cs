using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workrbot.Enums
{
    public enum EventTrigger : byte
    {
        [Display(Name = "Work Item Created")]
        WorkItemCreated = 0,
        [Display(Name = "Work Item Commented On")]
        WorkItemCommentedOn = 1,
        [Display(Name = "Work Item Deleted")]
        WorkItemDeleted = 2,
        [Display(Name = "Work Item Restored")]
        WorkItemRestored = 3,
        [Display(Name = "Work Item Updated")]
        WorkItemUpdated = 4

    }

    public static class EventTriggerExtensions
    {
        public static string ToFriendlyString(this EventTrigger me)
        {

            switch (me)
            {
                case EventTrigger.WorkItemCreated:
                    return "Work Item Created";
                case EventTrigger.WorkItemCommentedOn:
                    return "Work Item Commented On";

                case EventTrigger.WorkItemDeleted:
                    return "Work Item Deleted";

                case EventTrigger.WorkItemRestored:
                    return "Work Item Restored";

                case EventTrigger.WorkItemUpdated:
                    return "Work Item Updated";

                default:
                    return null;
            }
        }
    }
}