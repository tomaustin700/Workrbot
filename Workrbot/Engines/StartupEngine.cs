using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Workrbot.Classes;

namespace Workrbot.Engines
{
    public static class StartupEngine
    {
        public static void Init()
        {
            //var test = AppDomain.CurrentDomain.BaseDirectory;
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot"));
            Serialisation.SerializeObject(new Settings(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Settings.xml"));
            EventsEngine.CreateBlankEvents();
            GraphEngine.CreateBlankGraphData();
        }
    }
}