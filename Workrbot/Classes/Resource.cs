using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workrbot.Classes
{
    public class Resource
    {
        public int id { get; set; }
        public int rev { get; set; }
        
        public Fields fields { get; set; }
        public Revision revision { get; set; }
    }
}
