using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfigBuilderApp.Repositories
{
    public class ConfigBuilderRepository : IRepository<ConfigBuilder, string>
    {
        private ConfigBuilder m_ConfigBuilder;

        public ConfigBuilderRepository(string filePath)
        {
            this.FilePath = filePath;
            InternalReadConfigBuilderFromXmlFile();
        }

        public string FilePath { get; private set; }

        public void Add(ConfigBuilder instance)
        {
            // Save this instance as the only instance.
            m_ConfigBuilder = instance;
        }

        public List<ConfigBuilder> GetAll()
        {
            // Just return the only instance.
            return new List<ConfigBuilder>()
            {
                m_ConfigBuilder
            };
        }

        public ConfigBuilder GetById(string id)
        {
            // Just return the only instance.
            return m_ConfigBuilder;
        }

        public void Remove(ConfigBuilder instance)
        {
            // Nothing to do because repository has no list of ConfigBuilders.
        }

        public void SaveChanges()
        {
            InternalWriteConfigBuilderToXmlFile();
        }


        #region private functions
        private void InternalWriteConfigBuilderToXmlFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.FilePath);

            // Remove all known nodes
            XmlNode rootNode = document.SelectSingleNode("/ConfigBuilderConfiguration");
            XmlNode templatesFolderNode = document.SelectSingleNode("/ConfigBuilderConfiguration/TemplatesFolder");
            rootNode.RemoveChild(templatesFolderNode);
            XmlNode tempFolderNode = document.SelectSingleNode("/ConfigBuilderConfiguration/TempFolder");
            rootNode.RemoveChild(tempFolderNode);
            XmlNode batchFolderNode = document.SelectSingleNode("/ConfigBuilderConfiguration/BatchFolder");
            rootNode.RemoveChild(batchFolderNode);
            XmlNode infoFileNode = document.SelectSingleNode("/ConfigBuilderConfiguration/ConfigurationInfoFilePath");
            rootNode.RemoveChild(infoFileNode);

            // Create known nodes with values from ConfigBuilder instance.
            XmlElement newTemplatesFolderNode = document.CreateElement("TemplatesFolder");
            newTemplatesFolderNode.InnerText = m_ConfigBuilder.TemplatesFolder;
            rootNode.InsertBefore(newTemplatesFolderNode, rootNode.FirstChild);
            XmlElement newTempFolderNode = document.CreateElement("TempFolder");
            newTempFolderNode.InnerText = m_ConfigBuilder.TempFolder;
            rootNode.InsertBefore(newTempFolderNode, rootNode.FirstChild);
            XmlElement newBatchFolderNode = document.CreateElement("BatchFolder");
            newBatchFolderNode.InnerText = m_ConfigBuilder.BatchFolder;
            rootNode.InsertBefore(newBatchFolderNode, rootNode.FirstChild);
            XmlElement newInfoFileNode = document.CreateElement("ConfigurationInfoFilePath");
            newInfoFileNode.InnerText = m_ConfigBuilder.ConfigurationInfoFilePath;
            rootNode.InsertBefore(newInfoFileNode, rootNode.FirstChild);

            XmlNode settingsRootNode = document.SelectSingleNode("/ConfigBuilderConfiguration/Settings");
            foreach (Setting setting in m_ConfigBuilder.Settings)
            {
                settingsRootNode.RemoveAll();
                XmlElement settingNode = document.CreateElement("Setting");
                settingNode.SetAttribute("Key", setting.Key);
                settingNode.SetAttribute("Value", setting.Value);
                settingsRootNode.AppendChild(settingNode);
            }
            document.Save(this.FilePath);
        }

        private void InternalReadConfigBuilderFromXmlFile()
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

            this.m_ConfigBuilder = cb;
        }
        #endregion

    }
}
