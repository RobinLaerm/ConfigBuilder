using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class SubsystemKdr : Subsystem
    {
        public SubsystemKdr() : base("KDR")
        {
        }

        public bool Door { get; set; }
        public bool Klima { get; set; }
        public bool KlimaFST { get; set; }
        public bool Energie { get; set; }
    }
}
