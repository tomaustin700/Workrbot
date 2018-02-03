using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workrbot.Classes
{
    public class FieldsComment
    {
        [JsonProperty(PropertyName = "System.AreaPath")]
        public OldNewClass AreaPath { get; set; }

        [JsonProperty(PropertyName = "System.IterationPath")]
        public string IterationPath { get; set; }

        [JsonProperty(PropertyName = "System.TeamProject")]
        public string TeamProject { get; set; }

        [JsonProperty(PropertyName = "System.State")]
        public OldNewClass State { get; set; }

        [JsonProperty(PropertyName = "System.WorkItemType")]   
        public string WorkItemType { get; set; }

        [JsonProperty(PropertyName = "System.Reason")]
        public OldNewClass Reason { get; set; }
        
        [JsonProperty(PropertyName = "System.ChangedBy")]
        public string ChangedBy { get; set; }
        
        [JsonProperty(PropertyName = "System.AssignedTo")]
        public OldNewClass AssignedTo { get; set; }
        
        [JsonProperty(PropertyName = "System.History")]
        public string History { get; set; }

        [JsonProperty(PropertyName = "System.Tags")]
        public string Tags { get; set; }

        [JsonProperty(PropertyName = "System.CreatedBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "System.IntegrationBuild")]
        public OldNewClass IntegrationBuild { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.SystemInfo")]
        public string SystemInfo { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.ReproSteps")]
        public string ReproSteps { get; set; }

        [JsonProperty(PropertyName = "Microsoft.VSTS.TCM.AcceptanceCriteria")]
        public string AcceptanceCriteria { get; set; }

        [JsonProperty(PropertyName = "System.Description")]
        public string Description { get; set; }


    }
}
