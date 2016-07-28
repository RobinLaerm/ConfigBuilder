using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public abstract class Device
    {
        public Device(string id, string type)
        {
            this.Id = id;
            this.Type = type;
        }

        /// <summary>
        /// The unique identifier of this device.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The type of the device like "NAS", "NVR", "Camera", etc.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Reference to the ip address.
        /// </summary>
        public string ReferenceId { get; set; }
    }
}
