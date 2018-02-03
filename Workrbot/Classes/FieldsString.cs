using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workrbot.Classes
{
    public class FieldsString
    {
        [JsonProperty(PropertyName = "System.AreaPath")]
        public string AreaPath { get; set; }

        [JsonProperty(PropertyName = "System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty(PropertyName = "System.TeamProject")]
        public string TeamProject { get; set; }

        [JsonProperty(PropertyName = "System.State")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "System.WorkItemType")]
        public string WorkItemType { get; set; }

        [JsonProperty(PropertyName = "System.Reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.Urgency")]
        public string Urgency { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.BuildNumber")]
        public string BuildNumber { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.ZendeskId")]
        public string ZendeskId { get; set; }

        [JsonProperty(PropertyName = "System.History")]
        public string History { get; set; }

        [JsonProperty(PropertyName = "System.ChangedBy")]
        public string ChangedBy { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.WaitingOn")]
        public string WaitingOn { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.Correspondence")]
        public string Correspondence { get; set; }

        [JsonProperty(PropertyName = "System.AssignedTo")]
        public string AssignedTo { get; set; }
        
        [JsonProperty(PropertyName = "System.Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.WasEverTested")]
        public string WasEverTested { get; set; }

        [JsonProperty(PropertyName = "StreetsHeaver.WasEverBuilt")]
        public string WasEverBuilt { get; set; }

        [JsonProperty(PropertyName = "System.Tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "System.CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "System.IntegrationBuild")]
        public string IntegrationBuild { get; set; }

    }
}
