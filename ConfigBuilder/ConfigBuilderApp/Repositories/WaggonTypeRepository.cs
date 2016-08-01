using ConfigBuilderApp.Factory;
using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class WaggonTypeRepository
    {
        private Dictionary<string, WaggonType> m_WaggonTypes = new Dictionary<string, WaggonType>();

        public WaggonTypeRepository(string filePath)
        {
            this.FilePath = filePath;
            InternalReadWaggonTypesFromXmlFile();
        }

        public string FilePath { get; private set; }

        public List<WaggonType> GetAll()
        {
            List<WaggonType> waggonTypes = new List<WaggonType>();

            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            XmlNodeList waggonTypeNodes = document.SelectNodes("/ConfigBuilderConfiguration/WaggonTypes/WaggonType");
            foreach (XmlNode waggonTypeNode in waggonTypeNodes)
            {
                string name = waggonTypeNode.Attributes["Name"].Value;
                string usageName = waggonTypeNode.Attributes["Usage"].Value;
                WaggonType newWaggonType = new WaggonType(name, usageName);

                XmlNodeList cameraNodes = waggonTypeNode.SelectNodes("Cameras/Camera");
                foreach (XmlNode cameraNode in cameraNodes)
                {
                    string id = cameraNode.Attributes["Id"].Value;
                    string referenceId = cameraNode.Attributes["ReferenceId"].Value;
                    string cameraName = cameraNode.Attributes["Name"].Value;
                    Camera cam = new Camera(id);
                    cam.CameraType = "M3113";
                    cam.Group = "Innenkamera";
                    cam.Name = cameraName;
                    cam.ReferenceId = referenceId;
                    newWaggonType.AddCamera(cam);
                }

                waggonTypes.Add(newWaggonType);
            }

            return waggonTypes;
        }



        #region private functions
        private void InternalReadWaggonTypesFromXmlFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            XmlNodeList waggonTypeNodes = document.SelectNodes("/ConfigBuilderConfiguration/WaggonTypes/WaggonType");
            foreach (XmlNode waggonTypeNode in waggonTypeNodes)
            {
                WaggonType waggonType = CreateWaggonTypeFromXmlNode(waggonTypeNode);
                m_WaggonTypes.Add(waggonType.Name, waggonType);
            }
        }

        private void InternalWriteWaggonTypesIntoXmlFile()
        {
        }

        private WaggonType CreateWaggonTypeFromXmlNode(XmlNode waggonTypeNode)
        {
            string typeName = waggonTypeNode.Attributes["Name"].Value;
            string usageName = waggonTypeNode.Attributes["Usage"].Value;
            WaggonType waggonType = new WaggonType(typeName, usageName);

            // Kameras
            XmlNode camerasRootNode = waggonTypeNode.SelectSingleNode("Cameras");
            string cameraType = camerasRootNode["CameraType"].Value;
            XmlNodeList cameraNodes = waggonTypeNode.SelectNodes("Cameras/Camera");
            foreach (XmlNode cameraNode in cameraNodes)
            {
                Camera camera = CreateCameraFromXmlNode(cameraNode, cameraType);
                waggonType.AddCamera(camera);
            }

            // Devices
            XmlNodeList deviceNodes = waggonTypeNode.SelectNodes("Devices/Device");
            foreach (XmlNode deviceNode in deviceNodes)
            {
                Device device = CreateDeviceFromXmlNode(deviceNode);
                waggonType.AddDevice(device);
            }

            // Switches
            XmlNodeList switchNodes = waggonTypeNode.SelectNodes("Switches/Switch");
            foreach (XmlNode switchNode in switchNodes)
            {
                Switch mySwitch = CreateSwitchFromXmlNode(switchNode);
                waggonType.AddSwitch(mySwitch);
            }

            // Subsystems
            XmlNodeList subsystemNodes = waggonTypeNode.SelectNodes("Subsystems/Subsystem");
            foreach (XmlNode subsystemNode in subsystemNodes)
            {
                Subsystem subsystem = CreateSubsystemFromXmlNode(subsystemNode);
                waggonType.AddSubsystem(subsystem);
            }

            return waggonType;
        }

        private Subsystem CreateSubsystemFromXmlNode(XmlNode subsystemNode)
        {
            string referenceId = subsystemNode.Attributes["ReferenceId"].Value;
            Subsystem subsystem = SubsystemFactory.Create(referenceId, referenceId);

            // Todo: Es gibt verschiedene Subsysteme mit unterschiedlichen Attributen...

            return subsystem;
        }

        private Switch CreateSwitchFromXmlNode(XmlNode switchNode)
        {
            string referenceId = switchNode.Attributes["ReferenceId"].Value;
            string id = switchNode.Attributes["Id"].Value;
            string type = switchNode.Attributes["Type"].Value;
            Switch mySwitch = new Switch(id);
            mySwitch.ReferenceId = referenceId;
            mySwitch.SwitchType = type;
            return mySwitch;
        }

        private Device CreateDeviceFromXmlNode(XmlNode deviceNode)
        {
            string referenceId = deviceNode.Attributes["ReferenceId"].Value;
            string deviceType = deviceNode.Attributes["Type"].Value;
            Device device = DeviceFactory.Create(deviceType, referenceId);
            return device;
        }

        private Camera CreateCameraFromXmlNode(XmlNode cameraNode, string cameraType)
        {
            string referenceId = cameraNode.Attributes["ReferenceId"].Value;
            string id = cameraNode.Attributes["Id"].Value;
            string name = cameraNode.Attributes["Name"].Value;
            Camera camera = new Camera(id);
            camera.ReferenceId = referenceId;
            camera.Name = name;
            camera.Group = "";
            camera.CameraType = "";
            return camera;
        }

        #endregion

    }
}
