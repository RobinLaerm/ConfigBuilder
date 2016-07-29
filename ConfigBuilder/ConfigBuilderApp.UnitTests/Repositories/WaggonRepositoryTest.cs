using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Repositories;
using ConfigBuilderApp.Model;

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
        }

        [TestMethod]
        [DeploymentItem("Repositories\\ConfigBuilderConfiguration.xml")]
        public void WaggonRepository_LoadWaggonNumberTwice_OneWaggonWithTwoUsages()
        {
            WaggonRepository repository = new WaggonRepository(ConfigBuilderRepositoryFilePath);
            var waggons = repository.GetAll();
            var waggon = waggons.First(w => w.Identifier.Equals("508086-10000-0"));

            Assert.IsTrue(waggon.UsageNames.Count > 1);
        }

        [TestMethod]
        [DeploymentItem("Repositories\\WaggonConfiguration.xml")]
        [DeploymentItem("Repositories\\EmptyConfiguration.xml")]
        public void WaggonRepository_SaveAllChanges_AllWaggonsAreWrittenIntoFile()
        {
            WaggonRepository repository = new WaggonRepository("WaggonConfiguration.xml");
            Waggon waggon = CreateFakeWaggon("1234");
            repository.Save(waggon);
            repository.FilePath = "EmptyConfiguration.xml";
            repository.SaveChanges();

            WaggonRepository repository2 = new WaggonRepository("EmptyConfiguration.xml");
            var actual = repository2.GetAll().Count;

            Assert.AreEqual(409, actual);
        }


        private Waggon CreateFakeWaggon(string identifier)
        {
            Waggon waggon = new Waggon(identifier);
            waggon.IPGroup = "Test";
            waggon.IPMask = "1.1.1.x";
            waggon.TypeName = "R1234";
            waggon.AddUsageName("Test");
            return waggon;
        }

    }
}
