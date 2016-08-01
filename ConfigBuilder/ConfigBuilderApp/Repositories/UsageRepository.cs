using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class UsageRepository : IRepository<Usage, string>
    {
        private Dictionary<string, Usage> m_Usages = new Dictionary<string, Usage>();

        public UsageRepository(string filePath)
        {
            this.FilePath = filePath;
            InternalReadUsagesFromXmlFile();
        }

        public string FilePath { get; private set; }

        public void Add(Usage instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (m_Usages.ContainsKey(instance.Name) == true) throw new InvalidOperationException(string.Format("There is already a usage with name {0} in internal list.", instance.Name));
            m_Usages.Add(instance.Name, instance);
        }

        public List<Usage> GetAll()
        {
            return m_Usages.Values.ToList();
        }

        public Usage GetById(string id)
        {
            if (m_Usages.ContainsKey(id) == false) throw new KeyNotFoundException(string.Format("Cannot return Usage. There is no usage with name {0} in internal list.", id));
            return m_Usages[id];
        }

        public void Remove(Usage instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (m_Usages.ContainsKey(instance.Name) == false) throw new KeyNotFoundException(string.Format("Cannot remove usage. There is no usage with name {0} in internal list.", instance.Name));
            m_Usages.Remove(instance.Name);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException("Feature noch nicht implementiert.");
//            InternalWriteUsageIntoXmlFile();
        }



        #region private functions
        private void InternalReadUsagesFromXmlFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            XmlNodeList usageNodes = document.SelectNodes("/ConfigBuilderConfiguration/UsageActions/Actions");

            foreach (XmlNode usageNode in usageNodes)
            {
                string usageName = usageNode.Attributes["Usage"].Value;
                Usage usage = new Usage(usageName);

                // Todo: Die BuilderActions müssen noch geladen werden.

                m_Usages.Add(usageName, usage);
            }
        }

        private void InternalWriteUsageIntoXmlFile()
        {
        }
        #endregion
    }
}
