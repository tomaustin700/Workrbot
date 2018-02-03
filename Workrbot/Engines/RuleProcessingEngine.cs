using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workrbot.Classes;
using Workrbot.Enums;
using static Workrbot.Services.TFSServices;

namespace Workrbot.Engines
{
    public static class RuleProcessingEngine
    {
        private static Settings _settings { get; set; }
        public static void ProcessCommentPosted(TfsReturnComment returnData)
        {
            GetSettings();
            var events = GetEvents();
            foreach (var eventToProcess in events)
            {
                switch (eventToProcess.SecondaryTrigger)
                {
                    case SecondaryTrigger.Contains:
                        if (returnData.resource.fields.History.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && !returnData.resource.fields.ChangedBy.ToLower().Contains(("<"+_settings.Domain+"\\"+_settings.Username+">").ToLower()))
                        {
                            AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, EventTrigger.WorkItemCommentedOn);
                        }
                        break;
                    case SecondaryTrigger.DoesNotContain:
                        if (!returnData.resource.fields.History.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString()
                            && !returnData.resource.fields.ChangedBy.Contains(("<" + _settings.Domain + "\\" + _settings.Username + ">").ToLower()))
                        {
                            AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, EventTrigger.WorkItemCommentedOn);
                        }
                        break;
                    case SecondaryTrigger.HasLessThanXWords:
                        if (WordCount(returnData.resource.fields.History) < int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType 
                            == eventToProcess.WorkItemType.ToFriendlyString() && !returnData.resource.fields.ChangedBy.Contains(("<" + _settings.Domain + "\\" + _settings.Username + ">").ToLower()))
                        {
                            AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, EventTrigger.WorkItemCommentedOn);
                        }
                        break;
                    case SecondaryTrigger.HasMoreThanXWords:
                        if (WordCount(returnData.resource.fields.History) > int.Parse(eventToProcess.SecondaryTriggerActionValue) && 
                            returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && !returnData.resource.fields.ChangedBy.Contains(("<" + _settings.Domain + "\\" + _settings.Username + ">").ToLower()))
                        {
                            AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, EventTrigger.WorkItemCommentedOn);
                        }
                        break;
                }
            }
        }

        public static void ProcessWorkItemAction(TfsReturn returnData, EventTrigger trigger)
        {
            GetSettings();
            var events = GetEvents();
            foreach (var eventToProcess in events)
            {
                //Fix any unset fields to string.empty to stop errors
                switch (eventToProcess.WorkItemActionField)
                {
                    case WorkItemActionField.Description:
                        if (string.IsNullOrEmpty(returnData.resource.fields.Description))
                            returnData.resource.fields.Description = string.Empty;
                        break;
                    case WorkItemActionField.AcceptanceCriteria:
                        if (string.IsNullOrEmpty(returnData.resource.fields.AcceptanceCriteria))
                            returnData.resource.fields.AcceptanceCriteria = string.Empty;
                        break;
                    case WorkItemActionField.ReproSteps:
                        if (string.IsNullOrEmpty(returnData.resource.fields.ReproSteps))
                            returnData.resource.fields.ReproSteps = string.Empty;
                        break;
                    case WorkItemActionField.SystemInfo:
                        if (string.IsNullOrEmpty(returnData.resource.fields.SystemInfo))
                            returnData.resource.fields.SystemInfo = string.Empty;
                        break;
                    case WorkItemActionField.IterationPath:
                        if (string.IsNullOrEmpty(returnData.resource.fields.IterationPath))
                            returnData.resource.fields.IterationPath = string.Empty;
                        break;
                    default:
                        break;
                }

                switch (eventToProcess.SecondaryTrigger)
                {
                    case SecondaryTrigger.Contains:
                        switch (eventToProcess.WorkItemActionField)
                        {
                            case WorkItemActionField.Description:
                                if (returnData.resource.fields.Description.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.AcceptanceCriteria:
                                if (returnData.resource.fields.AcceptanceCriteria.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.ReproSteps:
                                if (returnData.resource.fields.ReproSteps.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.SystemInfo:
                                if (returnData.resource.fields.SystemInfo.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.IterationPath:
                                if (returnData.resource.fields.IterationPath.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case SecondaryTrigger.DoesNotContain:
                        switch (eventToProcess.WorkItemActionField)
                        {
                            case WorkItemActionField.Description:
                                if (!returnData.resource.fields.Description.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.AcceptanceCriteria:
                                if (!returnData.resource.fields.AcceptanceCriteria.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.ReproSteps:
                                if (!returnData.resource.fields.ReproSteps.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.SystemInfo:
                                if (!returnData.resource.fields.SystemInfo.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.IterationPath:
                                if (!returnData.resource.fields.IterationPath.Contains(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case SecondaryTrigger.HasLessThanXWords:
                        switch (eventToProcess.WorkItemActionField)
                        {
                            case WorkItemActionField.Description:
                                if (WordCount(returnData.resource.fields.Description) < int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.AcceptanceCriteria:
                                if (WordCount(returnData.resource.fields.AcceptanceCriteria) < int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.ReproSteps:
                                if (WordCount(returnData.resource.fields.ReproSteps) < int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.SystemInfo:
                                if (WordCount(returnData.resource.fields.SystemInfo) < int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.IterationPath:
                                if (WordCount(returnData.resource.fields.IterationPath) < int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case SecondaryTrigger.HasMoreThanXWords:
                        switch (eventToProcess.WorkItemActionField)
                        {
                            case WorkItemActionField.Description:
                                if (WordCount(returnData.resource.fields.Description) > int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.AcceptanceCriteria:
                                if (WordCount(returnData.resource.fields.AcceptanceCriteria) > int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.ReproSteps:
                                if (WordCount(returnData.resource.fields.ReproSteps) > int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.SystemInfo:
                                if (WordCount(returnData.resource.fields.SystemInfo) > int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            case WorkItemActionField.IterationPath:
                                if (WordCount(returnData.resource.fields.IterationPath) > int.Parse(eventToProcess.SecondaryTriggerActionValue) && returnData.resource.fields.WorkItemType == eventToProcess.WorkItemType.ToFriendlyString() && returnData.resource.fields.CreatedBy != _settings.Username)
                                {
                                    AddComment(returnData.resource.id, eventToProcess.Comment, eventToProcess.TagUser, eventToProcess.Project, returnData.resource.fields.CreatedBy, trigger);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        private static void GetSettings()
        {
            _settings = SettingsEngine.GetSettings();
        }
        private static void AddComment(int workItemId, string comment, bool tagUser, string project, string createdBy, EventTrigger trigger)
        {
            var workItem = GetWorkItem(workItemId, project);
            if (tagUser)
            {
                workItem.History = "<a href=\"mailto:" + _settings.Domain + "\\" + createdBy.Substring(createdBy.LastIndexOf('\\') + 1).Trim('>') + "\" " + "data-vss-mention=\"version:1.0\">@" + createdBy.Substring(createdBy.LastIndexOf('\\') + 1).Trim('>') + "</a>&nbsp; " + comment;
            }
            else
                workItem.History = comment;

            if (workItem.IsValid())
            {
                workItem.Save();
            }

            GraphEngine.AddGraphData(new GraphItem()
            {
                RepliedTo = createdBy,
                TimeOfReply = DateTime.Now,
                TriggerType = trigger
            });
        }

        private static WorkItem GetWorkItem(int workItemId, string project)
        {
            var connection = Connect(project);
            return connection.WorkItemStore.GetWorkItem(workItemId);

        }

        private static List<EventDTO> GetEvents()
        {
            return EventsEngine.Events;
        }
        
        private static int WordCount(string str)
        {
            int num = 0;
            bool wasInaWord = true;

            if (string.IsNullOrEmpty(str))
            {
                return num;
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (i != 0)
                {
                    if (str[i] == ' ' && str[i - 1] != ' ')
                    {
                        num++;
                        wasInaWord = false;
                    }
                }
                if (str[i] != ' ')
                {
                    wasInaWord = true;
                }
            }
            if (wasInaWord)
            {
                num++;
            }
            return num;
        }
    }
}