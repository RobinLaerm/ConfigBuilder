using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;
using ConfigBuilderApp.Repositories;

namespace ConfigBuilderApp.UnitTests.Repositories
{
    [TestClass]
    public class ConfigBuilderRepositoryTest
    {
        private static string ConfigBuilderRepositoryFilePath = "ConfigBuilderConfiguration.xml";

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void ConfigBuilderRepository_Get_PropertiesAreSet()
        {
            ConfigBuilderRepository repository = new ConfigBuilderRepository(ConfigBuilderRepositoryFilePath);
            ConfigBuilder configBuilder = repository.GetById("");
            Assert.IsFalse(string.IsNullOrEmpty(configBuilder.BatchFolder));
            Assert.IsFalse(string.IsNullOrEmpty(configBuilder.ConfigurationInfoFilePath));
            Assert.IsFalse(string.IsNullOrEmpty(configBuilder.TempFolder));
            Assert.IsFalse(string.IsNullOrEmpty(configBuilder.TemplatesFolder));
        }

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void ConfigBuilderRepository_SettingsAreLoaded()
        {
            ConfigBuilderRepository repository = new ConfigBuilderRepository(ConfigBuilderRepositoryFilePath);
            ConfigBuilder configBuilder = repository.GetById("");
            Assert.IsTrue(configBuilder.Settings.Count > 0);
        }

        [TestMethod]
        [DeploymentItem("Repositories\\EmptyConfiguration.xml")]
        public void ConfigBuilderRepository_SaveChanges_NewValuesAreWrittenToFile()
        {
            ConfigBuilderRepository repository = new ConfigBuilderRepository("EmptyConfiguration.xml");
            ConfigBuilder configBuilder = repository.GetById("");

            string templatesFolder = @"C:\TemplatesFolder";
            string tempFolder = @"C:\TempFolder";
            string batchFolder = @"C:\BatchFolder";
            string infoFilePath = @"C:\Info.txt";

            configBuilder.TemplatesFolder = templatesFolder;
            configBuilder.TempFolder = tempFolder;
            configBuilder.BatchFolder = batchFolder;
            configBuilder.ConfigurationInfoFilePath = infoFilePath;
            repository.SaveChanges();

            ConfigBuilderRepository repository2 = new ConfigBuilderRepository("EmptyConfiguration.xml");
            ConfigBuilder actual = repository2.GetById("");

            Assert.AreEqual(templatesFolder, actual.TemplatesFolder);
            Assert.AreEqual(tempFolder, actual.TempFolder);
            Assert.AreEqual(batchFolder, actual.BatchFolder);
            Assert.AreEqual(infoFilePath, actual.ConfigurationInfoFilePath);
        }

    }
}
