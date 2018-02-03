using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workrbot.Classes;
using Workrbot.Engines;
using Workrbot.Services;

namespace Workrbot.Controllers
{
    public class SettingsController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Settings";

            return View(SettingsEngine.GetSettings());
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username, Password, Domain, TFSUrl")] Settings @settings)
        {
            if (ModelState.IsValid)
            {
                SettingsEngine.SaveSettings(@settings);
                
                return RedirectToAction("Index", "Home");
            }
            return View(@settings);
        }

      
    }
}
