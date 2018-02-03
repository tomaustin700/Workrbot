using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workrbot.Enums
{
    public enum WorkItemType : byte
    {
        Bug = 0,
        [Display(Name = "User Story")]
        UserStory = 1,
        Feature = 2,
        Epic = 3,
        Task = 4,
        Issue = 5


    }

    public static class WorkItemTypeExtensions
    {
        public static string ToFriendlyString(this WorkItemType me)
        {
            switch (me)
            {
                case WorkItemType.Bug:
                case WorkItemType.Feature:
                case WorkItemType.Epic:
                case WorkItemType.Task:
                case WorkItemType.Issue:
                    return me.ToString();
                case WorkItemType.UserStory:
                    return "User Story";
                default:
                    return string.Empty;
            }
        }
    }
}