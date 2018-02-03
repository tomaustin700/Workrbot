using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workrbot.Classes
{
    public class Revision
    {
        public int id { get; set; }
        public string rev { get; set; }
        public FieldsString fields { get; set; }

    }
}
