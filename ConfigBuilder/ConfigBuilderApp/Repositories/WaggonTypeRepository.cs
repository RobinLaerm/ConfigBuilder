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
        public WaggonTypeRepository(string filePath)
        {
            this.FilePath = filePath;
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
    }
}
