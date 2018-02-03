using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workrbot.Classes;
using Workrbot.Engines;
using Workrbot.Enums;
using Workrbot.Services;

namespace Workrbot.Controllers
{
    public class LogsController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Logs";
            var data = GraphEngine.GetAllData();
            var output = new List<string>();

            foreach(var item in data)
            {
                output.Add(item.TriggerType.ToFriendlyString() + " - " + item.RepliedTo + " - " + item.TimeOfReply);
            }

            return View(output);
        }

       
    }
}
