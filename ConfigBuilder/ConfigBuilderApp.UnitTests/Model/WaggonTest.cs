using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class WaggonTest
    {
        [TestMethod]
        public void WaggonCtor_CreateNewWaggon_WaggonHasIdentifier()
        {
            string waggonNumber = "608068-91100-9";
            Waggon waggon = new Waggon(waggonNumber);

            Assert.AreEqual(waggonNumber, waggon.Identifier);
        }

        [TestMethod]
        public void Waggon_AddNewWaggonTypeWithUsage_Success()
        {
            string waggonNumber = "608068-91100-9";
            Waggon waggon = new Waggon(waggonNumber);
            waggon.TypeName = "R1234";
            waggon.AddUsageName("Video");
            waggon.AddUsageName("Diagnose");

            Assert.IsTrue(waggon.UsageNames.Count == 2);
        }

    }
}
