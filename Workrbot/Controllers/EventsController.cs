using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workrbot.Classes;
using Workrbot.Engines;
using Workrbot.Enums;

namespace Workrbot.Controllers
{
    public class EventsController : Controller
    {
        //private WorkrBotEntities db = new WorkrBotEntities();

        // GET: Events
        public ActionResult Index()
        {
            
            return View(EventsEngine.Events);
        }

        // GET: Events/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDTO @event = EventsEngine.Events.Where(x => x.EventId == id).First();
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,Name,TagUser,Comment,EventTrigger,SecondaryTrigger,SecondaryTriggerActionValue,WorkItemActionField,WorkItemType,Project")] EventDTO @event)
        {
            if (ModelState.IsValid)
            {
                EventsEngine.Events.Add(@event);
                EventsEngine.Save();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDTO @event = EventsEngine.Events.Where(x => x.EventId == id).First();

            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,Name,TagUser,Comment,EventTrigger,SecondaryTrigger,SecondaryTriggerActionValue,WorkItemActionField,WorkItemType,Project")] EventDTO @event)
        {
            if (ModelState.IsValid)
            {
                var events = EventsEngine.Events;
                EventsEngine.Events.Remove(EventsEngine.Events.Where(x => x.EventId == @event.EventId).First());
                EventsEngine.Events.Add(@event);
                EventsEngine.Save();
                

                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDTO @event = EventsEngine.Events.Where(x => x.EventId == id).First();

            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EventsEngine.Events = EventsEngine.Events.Where(x => x.EventId != id).ToList();
            EventsEngine.Save();

            return RedirectToAction("Index");
        }

       
    }
}
