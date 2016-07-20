using ConfigBuilderApp.Factory;
using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Bootstrapper
{
    public class DeutscheBahnDefaultBootstrapper : IBootstrapper
    {
        public void Bootstrap()
        {
            DeviceFactory.RegisterDeviceType("NAS", typeof(NetworkAttachedStorage));
            DeviceFactory.RegisterDeviceType("NVR", typeof(NetworkVideoRecorder));
        }
    }
}
