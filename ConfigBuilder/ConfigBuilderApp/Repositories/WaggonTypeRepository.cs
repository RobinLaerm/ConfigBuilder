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
                string usage = waggonTypeNode.Attributes["Usage"].Value;
                // Todo: Hier brauche ich eine Referenz auf die Usage...
//                WaggonType newWaggonType = new WaggonType(name, usage)

            }

            return waggonTypes;
        }
    }
}
