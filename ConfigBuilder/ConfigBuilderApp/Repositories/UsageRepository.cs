using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class UsageRepository
    {
        public UsageRepository(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public List<Usage> GetAll()
        {
            List<Usage> usages = new List<Usage>();

            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            var usageNodeList = document.SelectNodes("/ConfigBuilderConfiguration/UsageActions/Actions");
            
            // Todo:

            return usages;
        }
    }
}
