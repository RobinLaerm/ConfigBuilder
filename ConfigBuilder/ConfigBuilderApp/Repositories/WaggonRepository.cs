using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class WaggonRepository : IRepository<Waggon, string>
    {
        private Dictionary<string, Waggon> m_Waggons = new Dictionary<string, Waggon>();

        public WaggonRepository(string filePath)
        {
            this.FilePath = filePath;
            InternalLoadAllWaggonsFromFile();
        }

        public string FilePath { get; set; }

        public List<Waggon> GetAll()
        {
            return m_Waggons.Values.ToList();
        }

        public Waggon GetById(string id)
        {
            if (m_Waggons.ContainsKey(id) == false) throw new KeyNotFoundException(string.Format("Cannot return waggon. Waggon with id {0} not found.", id));
            return m_Waggons[id];
        }

        public void Add(Waggon waggon)
        {
            if (waggon == null) throw new ArgumentNullException("waggon");
            if (m_Waggons.ContainsKey(waggon.Identifier)) throw new InvalidOperationException(string.Format("Cannot add waggon. Waggon with id {0} already exists."));
            m_Waggons.Add(waggon.Identifier, waggon);
        }

        public void Remove(Waggon waggon)
        {
            if (waggon == null) throw new ArgumentNullException("waggon");
            if (m_Waggons.ContainsKey(waggon.Identifier) == false) throw new InvalidOperationException(string.Format("Cannot remove waggon. Waggon wit id {0} does not exist."));
            m_Waggons.Remove(waggon.Identifier);
        }

        public void SaveChanges()
        {
            InternalWriteAllWaggonsToFile();
        }

        private void InternalWriteAllWaggonsToFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            XmlNode waggonNumbersNode = document.SelectSingleNode("/ConfigBuilderConfiguration/WaggonNumbers");
            waggonNumbersNode.RemoveAll();

            foreach (Waggon waggon in m_Waggons.Values)
            {
                foreach (string usage in waggon.UsageNames)
                {
                    var waggonNode = CreateNewWaggonNode(document, waggon, usage);
                    waggonNumbersNode.AppendChild(waggonNode);
                }
            }
            document.Save(this.FilePath);
        }

        private void InternalLoadAllWaggonsFromFile()
        {
            m_Waggons.Clear();

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
                    string usageName = waggonNumberNode.Attributes["Usage"].Value;
                    waggon.AddUsageName(usageName);

                }
                else
                {
                    waggon = CreateNewWaggonFromXmlNode(waggonNumberNode);
                    m_Waggons.Add(waggon.Identifier, waggon);
                }
            }
        }

        private Waggon CreateNewWaggonFromXmlNode(XmlNode waggonNumberNode)
        {
            string identifier = waggonNumberNode.Attributes["Identifier"].Value;
            string ipMask = waggonNumberNode.Attributes["IPMask"].Value;
            string ipGroup = waggonNumberNode.Attributes["IPGroup"].Value;
            string typeName = waggonNumberNode.Attributes["WaggonType"].Value;
            string usageName = waggonNumberNode.Attributes["Usage"].Value;

            Waggon waggon = new Waggon(identifier);
            waggon.IPMask = ipMask;
            waggon.IPGroup = ipGroup;
            waggon.TypeName = typeName;
            waggon.AddUsageName(usageName);
            return waggon; 
        }

        private XmlElement CreateNewWaggonNode(XmlDocument document, Waggon waggon, string usage)
        {
            XmlElement waggonNode = document.CreateElement("WaggonNumber");
            waggonNode.SetAttribute("Identifier", waggon.Identifier);
            waggonNode.SetAttribute("IPMask", waggon.IPMask);
            waggonNode.SetAttribute("WaggonType", waggon.TypeName);
            waggonNode.SetAttribute("IPGroup", waggon.IPGroup);
            waggonNode.SetAttribute("Usage", usage);
            return waggonNode;
        }

    }
}
