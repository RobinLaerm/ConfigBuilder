using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class Switch : Device
    {
        public Switch(string id) : base(id, "Switch")
        {
        }

        public string SwitchType { get; set; }

    }
}
