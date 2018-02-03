using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Workrbot.Classes;

namespace Workrbot.Engines
{
    public static class EventsEngine
    {
        private static List<EventDTO> _events;
        public static List<EventDTO> Events
        {
            get
            {
                if (_events == null)
                {
                    _events = GetEvents();
                    return _events;
                }
                else
                    return _events;
            }
            set
            {
                _events = value;
                SetEvents(_events);
            }
        }
        private static List<EventDTO> GetEvents()
        {
            return Serialisation.DeSerializeObject<SavedEvents>(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Events.xml")).Events;
        }

        private static void SetEvents(List<EventDTO> events)
        {
            Serialisation.SerializeObject(new SavedEvents() { Events = events }, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Events.xml"));
        }

        public static void Save()
        {
            Serialisation.SerializeObject(new SavedEvents() { Events = Events }, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Events.xml"));
        }

        public static void CreateBlankEvents()
        {
            Serialisation.SerializeObject(new SavedEvents(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Workrbot", "Events.xml"));
        }
    }
}