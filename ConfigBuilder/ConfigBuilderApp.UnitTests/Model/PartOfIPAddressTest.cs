using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class PartOfIPAddressTest
    {
        [TestMethod]
        public void PartOfIPAddressCtor_CreateInstanceWithParameters_InstanceIsCorrectInitialized()
        {
            PartOfIPAddress ip = new PartOfIPAddress("1", "40");

            Assert.AreEqual("1", ip.ReferenceId);
            Assert.AreEqual("40", ip.Part);
        }

        [TestMethod]
        public void PartOfIPAddress_EqualsWithTwoInstances_InstancesAreEqual()
        {
            PartOfIPAddress expected = new PartOfIPAddress("1", "40");
            PartOfIPAddress actual = new PartOfIPAddress("1", "40");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PartOfIPAddress_EqualsWithTwoInstances_InstancesAreNotEqual()
        {
            PartOfIPAddress expected = new PartOfIPAddress("1", "40");
            PartOfIPAddress actual = new PartOfIPAddress("2", "40");

            Assert.AreNotEqual(expected, actual);
        }

    }
}
