using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Repositories;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Repositories
{
    [TestClass]
    public class IPAddressRepositoryTest
    {
        private static string ConfigBuilderRepositoryFilePath = "ConfigBuilderConfiguration.xml";

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void IPAddressRepository_IPAddressesAreLoaded()
        {
            IPAddressRepository repository = new IPAddressRepository(ConfigBuilderRepositoryFilePath);
            var ipAddressList = repository.GetAll();
            Assert.IsTrue(ipAddressList.Count > 0);
        }

        [TestMethod]
        [DeploymentItem("Repositories\\EmptyConfiguration.xml")]
        public void IPAddressRepository_SaveChanges_IPAddressesAreWrittenIntoFile()
        {
            IPAddressRepository repository = new IPAddressRepository("EmptyConfiguration.xml");
            PartOfIPAddress expected = new PartOfIPAddress("Cam1", "x.x.x.139");
            repository.Add(expected);
            repository.SaveChanges();

            IPAddressRepository repository2 = new IPAddressRepository("EmptyConfiguration.xml");
            PartOfIPAddress actual = repository2.GetById("Cam1");

            Assert.AreEqual(expected.ReferenceId, actual.ReferenceId);
            Assert.AreEqual(expected.Part, actual.Part);
            Assert.AreEqual(expected, actual);
        }

    }
}
