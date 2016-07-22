using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class ConfigBuilderRepository
    {
        public ConfigBuilderRepository(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }

        public ConfigBuilder Get()
        {
            ConfigBuilder cb = new ConfigBuilder();
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);
            cb.BatchFolder = document.SelectSingleNode("/ConfigBuilderConfiguration/BatchFolder").InnerText;
            cb.ConfigurationInfoFilePath = document.SelectSingleNode("/ConfigBuilderConfiguration/ConfigurationInfoFilePath").InnerText;
            cb.TempFolder = document.SelectSingleNode("/ConfigBuilderConfiguration/TempFolder").InnerText;
            cb.TemplatesFolder = document.SelectSingleNode("/ConfigBuilderConfiguration/TemplatesFolder").InnerText;

            XmlNodeList settingNodes = document.SelectNodes("/ConfigBuilderConfiguration/Settings/Setting");
            foreach (XmlNode settingNode in settingNodes)
            {
                string key = settingNode.Attributes["Key"].Value;
                string val = settingNode.Attributes["Value"].Value;
                cb.AddSetting(new Setting(key, val));
            }

            return cb;
        }

        public void Save(ConfigBuilder configBuilder)
        {
        }
    }
}
