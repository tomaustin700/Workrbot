using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workrbot.Classes;
using Workrbot.Engines;

namespace Workrbot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Workrbot";
            var graphData = GraphEngine.GetRepliesData();
            ViewBag.Names = graphData.Item1;
            ViewBag.Counts = graphData.Item2;
            var secondGraphData = GraphEngine.GetHistoryData();
            ViewBag.Types = secondGraphData.Item1;
            ViewBag.EventCounts = secondGraphData.Item2;
            //var output = new GraphOutput() { Names = , RepliedCount = graphData.Item2 };

            return View();
        }
    }
}
