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
            WaggonTypeWithUsage expected = new WaggonTypeWithUsage("R1234", "Video");

            waggon.AddWaggonTypeWithUsageList(new WaggonTypeWithUsage("R1234", "Video"));
            waggon.AddWaggonTypeWithUsageList(new WaggonTypeWithUsage("R1234", "Diagnose"));
            WaggonTypeWithUsage actual = waggon.GetWaggonTypeWithUsage("R1234", "Video");

            Assert.AreEqual(2, waggon.WaggonTypeWithUsageList.Count);
            Assert.AreEqual(expected, actual);
        }

    }
}
