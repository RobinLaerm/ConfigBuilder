using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Repositories;

namespace ConfigBuilderApp.UnitTests.Repositories
{
    [TestClass]
    public class WaggonRepositoryTest
    {
        private static string ConfigBuilderRepositoryFilePath = "ConfigBuilderConfiguration.xml";

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void WaggonRepository_WaggonsAreLoaded()
        {
            WaggonRepository repository = new WaggonRepository(ConfigBuilderRepositoryFilePath);
            var waggons = repository.GetAll();
            Assert.IsTrue(waggons.Count > 0);
        }

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void WaggonRepository_AllPropertiesOfWaggonSet()
        {
            WaggonRepository repository = new WaggonRepository(ConfigBuilderRepositoryFilePath);
            var waggons = repository.GetAll();
            var waggon = waggons.First(w => w.Identifier.Equals("508086-10000-0"));

            Assert.AreEqual(waggon.Identifier, "508086-10000-0");
            Assert.AreEqual(waggon.IPGroup, "DB");
            Assert.AreEqual(waggon.IPMask, "10.228.10.x");
            Assert.IsTrue(waggon.WaggonTypeWithUsageList.Count > 0);
        }

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void WaggonRepository_LoadWaggonNumberTwice_OneWaggonWithTwoWaggonTypes()
        {
            WaggonRepository repository = new WaggonRepository(ConfigBuilderRepositoryFilePath);
            var waggons = repository.GetAll();
            var waggon = waggons.First(w => w.Identifier.Equals("508086-10000-0"));

            Assert.IsTrue(waggon.WaggonTypeWithUsageList.Count > 1);
        }
    }
}
