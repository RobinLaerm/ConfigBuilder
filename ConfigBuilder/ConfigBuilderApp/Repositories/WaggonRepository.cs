using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class WaggonRepository
    {
        private Dictionary<string, Waggon> m_Waggons = new Dictionary<string, Waggon>();

        public WaggonRepository(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }


        public List<Waggon> GetAll()
        {
            m_Waggons.Clear();
            List<Waggon> waggons = new List<Waggon>();

            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            XmlNodeList waggonNumberNodes = document.SelectNodes("/ConfigBuilderConfiguration/WaggonNumbers/WaggonNumber");
            foreach (XmlNode waggonNumberNode in waggonNumberNodes)
            {
                string identifier = waggonNumberNode.Attributes["Identifier"].Value;

                Waggon waggon = null;
                if (m_Waggons.ContainsKey(identifier) == true)
                {
                    waggon = m_Waggons[identifier];
                }
                else
                {
                    string ipMask = waggonNumberNode.Attributes["IPMask"].Value;
                    string ipGroup = waggonNumberNode.Attributes["IPGroup"].Value;
                    waggon = new Waggon(identifier);
                    waggon.IPMask = ipMask;
                    waggon.IPGroup = ipGroup;
                    waggons.Add(waggon);
                    m_Waggons.Add(waggon.Identifier, waggon);
                }

                string typeName = waggonNumberNode.Attributes["WaggonType"].Value;
                string usageName = waggonNumberNode.Attributes["Usage"].Value;
                waggon.AddWaggonTypeWithUsageList(new WaggonTypeWithUsage(typeName, usageName));
            }

            return waggons;
        }
    }
}
