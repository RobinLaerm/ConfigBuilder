using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class IPMaskTest
    {
        [TestMethod]
        public void IPMaskCtor_CreateInstanceWithMask_InstanceCorrectInitialized()
        {
            string expected = "10.20.30.x";
            IPMask mask = new IPMask(expected);
            string actual = mask.Mask;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Combine_MaskWithPartOfIPAddress_ReturnsCorrectIPAddress()
        {
            string expected = "10.20.30.40";
            IPMask mask = new IPMask("10.20.30.x");
            string actual = mask.Combine("40");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Combine_MaskWithPartOfIPAddressAndPlaceholder_ReturnsCorrectIPAddress()
        {
            string expected = "10.20.30.40";
            IPMask mask = new IPMask("10.20.30.x");
            string actual = mask.Combine("x.x.x.40");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Combine_MaskWithPartOfIPAddressAndPlaceholder2_ReturnsCorrectIPAddress()
        {
            string expected = "10.20.30.40";
            IPMask mask = new IPMask("10.20.x.x");
            string actual = mask.Combine("x.x.30.40");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Combine_MaskWithPartOfIPAddressAndPlaceholder3_ReturnsCorrectIPAddress()
        {
            string expected = "10.20.30.40";
            IPMask mask = new IPMask("10.x.x.x");
            string actual = mask.Combine("x.20.30.40");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Combine_MaskWithPartOfIPAddressAndPlaceholder4_ReturnsCorrectIPAddress()
        {
            string expected = "10.20.30.40";
            IPMask mask = new IPMask("x.x.x.x");
            string actual = mask.Combine("10.20.30.40");

            Assert.AreEqual(expected, actual);
        }

    }
}
