using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workrbot.Classes
{
    [Serializable]
    public class SavedEvents
    {
        public List<EventDTO> Events { get; set; }

        public SavedEvents()
        {
            Events = new List<EventDTO>();
        }
    }
}