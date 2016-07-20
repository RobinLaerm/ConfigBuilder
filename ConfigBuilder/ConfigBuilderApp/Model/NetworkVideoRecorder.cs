using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class NetworkVideoRecorder : Device
    {
        public NetworkVideoRecorder(string id) : base(id, "NVR")
        {
        }
    }
}
