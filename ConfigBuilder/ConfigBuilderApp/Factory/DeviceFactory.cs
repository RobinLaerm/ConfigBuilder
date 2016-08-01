using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Factory
{
    public class DeviceFactory
    {
        public static Device Create(string type, string id)
        {
            switch (type)
            {
                case "NVR":
                    {
                        return new NetworkVideoRecorder(id);
                    }
                case "NAS":
                    {
                        return new NetworkAttachedStorage(id);
                    }
                default:
                    {
                        throw new Exception(string.Format("Cannot create device of type {0}. Unknown device type.", type));
                    }
            }
        }
    }
}
