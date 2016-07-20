using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class SubsystemWithIPAddress : Subsystem
    {
        public SubsystemWithIPAddress(string type) : base(type)
        {
        }

        public PartOfIPAddress PartOfIPAddress { get; set; }
    }
}
