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
            ConfigBuilder configBuilder = repository.Get();
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
            ConfigBuilder configBuilder = repository.Get();
            Assert.IsTrue(configBuilder.Settings.Count > 0);
        }

    }
}
