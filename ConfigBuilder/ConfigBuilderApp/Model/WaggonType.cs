using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class WaggonType
    {
        private List<Camera> m_Cameras;
        private List<Device> m_Devices;
        private List<Switch> m_Switches;
        private List<Subsystem> m_Subsystems;

        /// <summary>
        /// Creates an immutable instance that combines a waggonType with a usage.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="usage"></param>
        public WaggonType(string typeName, string usageName)
        {
            this.Name = typeName;
            this.UsageName = usageName;
            this.Cameras = this.m_Cameras = new List<Camera>();
            this.Devices = this.m_Devices = new List<Device>();
            this.Switches = this.m_Switches = new List<Switch>();
            this.Subsystems = this.m_Subsystems = new List<Subsystem>();
        }

        /// <summary>
        /// The name of the waggon type.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The specific usage this waggon type is for. This is a reference to the id.
        /// </summary>
        public readonly string UsageName;

        public IReadOnlyCollection<Camera> Cameras { get; private set; }

        public IReadOnlyCollection<Device> Devices { get; private set; }

        public IReadOnlyCollection<Switch> Switches { get; private set; }

        public IReadOnlyCollection<Subsystem> Subsystems { get; private set; }

        #region Camera functions
        public void AddCamera(Camera camera)
        {
            if (camera == null) throw new ArgumentNullException("camera");
            if (m_Cameras.Contains(camera)) throw new InvalidOperationException("There is already an instance of Camera with the same id in list.");
            m_Cameras.Add(camera);
        }

        public Camera GetCamera(string id)
        {
            return m_Cameras.First(c => c.Id.Equals(id));
        }

        public void RemoveCamera(string id)
        {
            var camera = GetCamera(id);
            this.m_Cameras.Remove(camera);
        }
        #endregion

        #region Device functions
        public void AddDevice(Device device)
        {
            if (device == null) throw new ArgumentNullException("device");
            if (m_Devices.Contains(device)) throw new InvalidOperationException("There is already an instance of device with the same id in list.");
            m_Devices.Add(device);
        }

        public Device GetDevice(int id)
        {
            return m_Devices.First(d => d.Id.Equals(id));
        }

        public void RemoveDevice(int id)
        {
            var device = GetDevice(id);
            m_Devices.Remove(device);
        }
        #endregion

        #region Switch functions
        public void AddSwitch(Switch newSwitch)
        {
            if (newSwitch == null) throw new ArgumentNullException("newSwitch");
            if (m_Switches.Contains(newSwitch)) throw new InvalidOperationException("newSwitch");
            m_Switches.Add(newSwitch);
        }

        public Switch GetSwitch(string id)
        {
            return m_Switches.First(s => s.Id.Equals(id));
        }

        public void RemoveSwitch(string id)
        {
            var mySwitch = GetSwitch(id);
            m_Switches.Remove(mySwitch);
        }

        #endregion

        #region Subsystem functions
        public void AddSubsystem(Subsystem subsystem)
        {
            if (subsystem == null) throw new ArgumentNullException("subsystem");
            if (m_Subsystems.Contains(subsystem)) throw new InvalidOperationException("There is already a subsystem with the same id in internal list.");
            m_Subsystems.Add(subsystem);
        }

        public Subsystem GetSubsystem(string id)
        {
            return m_Subsystems.First(s => s.Type.Equals(id));
        }

        public void RemoveSubsystem(string id)
        {
            var subsystem = GetSubsystem(id);
            m_Subsystems.Remove(subsystem);
        }

        #endregion

        public override bool Equals(object obj)
        {
            WaggonType waggonType = obj as WaggonType;
            if (waggonType == null) return false;
            return this.Name.Equals(waggonType.Name)
                && this.UsageName.Equals(waggonType.UsageName);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() | this.UsageName.GetHashCode();
        }
    }
}
