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
        public void ConfigBuilderRepository_WaggonsAreLoaded()
        {
            WaggonRepository repository = new WaggonRepository(ConfigBuilderRepositoryFilePath);
            var waggons = repository.GetAll();
            Assert.IsTrue(waggons.Count > 0);
        }

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void ConfigBuilderRepository_LoadWaggonNumberTwice_OneWaggonWithTwoWaggonTypes()
        {
            WaggonRepository repository = new WaggonRepository(ConfigBuilderRepositoryFilePath);
            var waggons = repository.GetAll();
            var waggon = waggons.Where(w => w.WaggonNumber.Identifier.Equals("508086-10000-0"));
        }
    }
}
