using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class SubsystemRelay : Subsystem
    {
        public SubsystemRelay() : base("Relay")
        {
        }

        public string BinaryInput1 { get; set; }
        public string BinaryInput2 { get; set; }
        public string BinaryInput3 { get; set; }
        public string BinaryInput4 { get; set; }
        public string BinaryOutput1 { get; set; }

    }
}
