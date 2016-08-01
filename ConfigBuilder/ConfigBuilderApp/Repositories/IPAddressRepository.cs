using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class IPAddressRepository : IRepository<PartOfIPAddress, string>
    {
        private Dictionary<string, PartOfIPAddress> m_IPAddresses = new Dictionary<string, PartOfIPAddress>();

        public IPAddressRepository(string filePath)
        {
            this.FilePath = filePath;
            InternalReadIpAddressesFromXmlFile();
        }

        public string FilePath { get; private set; }

        public void Add(PartOfIPAddress instance)
        {
            if (instance == null) throw new ArgumentNullException("intance");
            if (m_IPAddresses.ContainsKey(instance.ReferenceId) == true) throw new InvalidOperationException(string.Format("There is already a ip address with id {0} in internal list.", instance.ReferenceId));
            m_IPAddresses.Add(instance.ReferenceId, instance);
        }

        public List<PartOfIPAddress> GetAll()
        {
            return m_IPAddresses.Values.ToList();
        }

        public PartOfIPAddress GetById(string id)
        {
            if (m_IPAddresses.ContainsKey(id) == false) throw new KeyNotFoundException(string.Format("Cannot return instance. IpAddress with id {0} not found.", id));
            return m_IPAddresses[id];
        }

        public void Remove(PartOfIPAddress instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (m_IPAddresses.ContainsKey(instance.ReferenceId) == false) throw new InvalidOperationException(string.Format("Cannot remove instance. IpAddress with id {0} does not exist.", instance.ReferenceId));
            m_IPAddresses.Remove(instance.ReferenceId);
        }

        public void SaveChanges()
        {
            InternalWriteIpAddressesIntoXmlFile();
        }


        #region private functions
        private void InternalReadIpAddressesFromXmlFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);

            XmlNodeList ipAddressNodes = document.SelectNodes("/ConfigBuilderConfiguration/IPAddresses/IPAddress");
            foreach (XmlNode ipAddressNode in ipAddressNodes)
            {
                string referenceId = ipAddressNode.Attributes["ReferenceId"].Value;
                string partOfIpAddress = ipAddressNode.Attributes["PartOfIPAddress"].Value;
                string ipGroup = ipAddressNode.Attributes["IPGroup"].Value;
                PartOfIPAddress ip = new PartOfIPAddress(referenceId, partOfIpAddress);
                m_IPAddresses.Add(referenceId, ip);
            }
        }

        private void InternalWriteIpAddressesIntoXmlFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            XmlNode ipAddressRootNode = document.SelectSingleNode("/ConfigBuilderConfiguration/IPAddresses");
            ipAddressRootNode.RemoveAll();
            foreach (PartOfIPAddress ip in m_IPAddresses.Values)
            {
                XmlNode ipNode = CreateIpAddressNode(document, ip);
                ipAddressRootNode.AppendChild(ipNode);
            }
            document.Save(this.FilePath);
        }

        private XmlNode CreateIpAddressNode(XmlDocument document, PartOfIPAddress ip)
        {
            var ipNode = document.CreateElement("IPAddress");
            ipNode.SetAttribute("ReferenceId", ip.ReferenceId);
            ipNode.SetAttribute("PartOfIPAddress", ip.Part);
            ipNode.SetAttribute("IPGroup", "DB");
            return ipNode;
        }
        #endregion
    }
}
