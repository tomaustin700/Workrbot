using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workrbot.Classes
{
    public class TfsReturnComment
    {
        //public int id { get; set; }
        public string eventType { get; set; }

        public string publisherId { get; set; }

        public string createdDate { get; set; }

        public ResourceComment resource { get; set; }

        public Message message { get; set; }

        public Message detailedMessage { get; set; }
        public ResourceContainers resourceContainers { get; set; }

    }
}
