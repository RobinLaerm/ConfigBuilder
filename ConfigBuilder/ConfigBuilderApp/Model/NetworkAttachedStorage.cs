using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class NetworkAttachedStorage : Device
    {
        public NetworkAttachedStorage(string id) : base(id, "NAS")
        {
        }
    }
}
