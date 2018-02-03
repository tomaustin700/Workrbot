using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Workrbot.Classes;
using Workrbot.Enums;
using Workrbot.Extension_Methods;

namespace Workrbot.Engines
{
    public class GraphEngine
    {
        public static void CreateBlankGraphData()
        {
            Serialisation.SerializeObject(new GraphData(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "GraphData.xml"));
        }

        private static GraphData GetGraphData()
        {
            return Serialisation.DeSerializeObject<GraphData>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "GraphData.xml"));
        }

        public static void SaveGraphData(GraphData graphData)
        {
            Serialisation.SerializeObject(graphData, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "GraphData.xml"));
        }

        public static void AddGraphData(GraphItem item)
        {
            var data = GetGraphData();
            data.GraphItems.Add(item);
            SaveGraphData(data);
        }

        public static List<GraphItem> GetAllData()
        {
            return  GetGraphData().GraphItems;   
        }

        public static Tuple<List<string>, List<int>> GetHistoryData()
        {
            var graphData = GetGraphData();
            var eventType = new List<string>();
            var triggerCount = new List<int>();
            foreach (var data in graphData.GraphItems.DistinctBy(x => x.TriggerType))
            {
                eventType.Add(data.TriggerType.ToFriendlyString());
            }

            foreach (var trigger in eventType)
            {
                triggerCount.Add(graphData.GraphItems.Where(x => x.TriggerType.ToFriendlyString() == trigger).Count());
            }

            return new Tuple<List<string>, List<int>>(eventType, triggerCount);
        }

        public static Tuple<List<string>, List<int>> GetRepliesData()
        {
            var graphData = GetGraphData();
            var names = new List<string>();
            var repliedCount = new List<int>();
            foreach (var data in graphData.GraphItems.DistinctBy(x => x.RepliedTo))
            {
                names.Add(data.RepliedTo);
            }

            foreach (var person in names)
            {
                repliedCount.Add(graphData.GraphItems.Where(x => x.RepliedTo == person).Count());
            }

            return new Tuple<List<string>, List<int>>(names, repliedCount);

        }
    }


}