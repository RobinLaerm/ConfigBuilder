using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class Subsystem
    {
        public Subsystem(string type)
        {
            this.Type = type;
        }

        public string Type { get; private set; }
    }
}
