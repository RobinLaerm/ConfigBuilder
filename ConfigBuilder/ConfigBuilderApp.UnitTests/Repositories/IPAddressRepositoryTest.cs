using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Repositories;

namespace ConfigBuilderApp.UnitTests.Repositories
{
    [TestClass]
    public class IPAddressRepositoryTest
    {
        private static string ConfigBuilderRepositoryFilePath = "ConfigBuilderConfiguration.xml";

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void ConfigBuilderRepository_IPAddressesAreLoaded()
        {
            IPAddressRepository repository = new IPAddressRepository(ConfigBuilderRepositoryFilePath);
            var ipAddressList = repository.GetAll();
            Assert.IsTrue(ipAddressList.Count > 0);
        }
    }
}
