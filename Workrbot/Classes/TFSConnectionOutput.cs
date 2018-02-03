using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workrbot.Classes
{
    public class TFSConnectionOutput 
    {
        public WorkItemStore WorkItemStore { get; set; }
        public Microsoft.TeamFoundation.WorkItemTracking.Client.Project TeamProject { get; set; }
        public WorkItemType WorkItemType { get; set; }
        public TfsTeamProjectCollection TeamProjectCollection { get; set; }

       
    }
}