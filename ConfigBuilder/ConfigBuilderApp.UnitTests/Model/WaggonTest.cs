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
            Waggon waggon = new Waggon(new WaggonNumber(waggonNumber));

            Assert.AreEqual(waggonNumber, waggon.WaggonNumber.Identifier);
        }

    }
}
