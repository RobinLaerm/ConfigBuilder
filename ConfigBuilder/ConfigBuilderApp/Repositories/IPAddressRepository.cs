using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class IPAddressRepository
    {
        public IPAddressRepository(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public List<PartOfIPAddress> GetAll()
        {
            List<PartOfIPAddress> ipAddressList = new List<PartOfIPAddress>();

            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);

            XmlNodeList ipAddressNodes = document.SelectNodes("/ConfigBuilderConfiguration/IPAddresses/IPAddress");
            foreach (XmlNode ipAddressNode in ipAddressNodes)
            {
                string referenceId = ipAddressNode.Attributes["ReferenceId"].Value;
                string partOfIpAddress = ipAddressNode.Attributes["PartOfIPAddress"].Value;
                string ipGroup = ipAddressNode.Attributes["IPGroup"].Value;
                ipAddressList.Add(new PartOfIPAddress(referenceId, partOfIpAddress));
            }
            return ipAddressList;
        }
    }
}
