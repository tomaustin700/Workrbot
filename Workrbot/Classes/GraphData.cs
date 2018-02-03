using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workrbot.Enums;

namespace Workrbot.Classes
{
    [Serializable]
    public class GraphData
    {
        public List<GraphItem> GraphItems { get; set; }
    }
}