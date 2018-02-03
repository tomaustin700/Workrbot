using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Workrbot.Classes;
using Workrbot.Engines;

namespace Workrbot.Services
{
    public class TFSServices
    {
        private static Settings _settings { get; set; }

        public static TFSConnectionOutput Connect(string project)
        {
            _settings = SettingsEngine.GetSettings();

            TFSConnectionOutput output = new TFSConnectionOutput();

            NetworkCredential networkCredentials = new NetworkCredential(_settings.Username, SettingsEngine.GetPassword(_settings), _settings.Domain);
            Microsoft.VisualStudio.Services.Common.WindowsCredential windowsCredentials = new Microsoft.VisualStudio.Services.Common.WindowsCredential(networkCredentials);

            // Converts windows credential to tfs credentials which can be used to access tfs 
            VssCredentials tfsCredentials = new VssCredentials(windowsCredentials);
            
            output.TeamProjectCollection = new TfsTeamProjectCollection(_settings.CollectionUri, tfsCredentials);
            output.TeamProjectCollection.Authenticate();
            output.WorkItemStore = output.TeamProjectCollection.GetService<WorkItemStore>();

            Guid projectGuid = new Guid();
            Guid.TryParse(project, out projectGuid);

            return output;
        }

       
    }
}