using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class WaggonNumberTest
    {
        [TestMethod]
        public void WaggonNumberTest_Ctor_IdentifierIsSet()
        {
            string expected = "1234";
            WaggonNumber number = new WaggonNumber(expected);
            string actual = number.Identifier;

            Assert.IsNotNull(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WaggonNumberTest_StaticCreateNew_IdentifierIsSet()
        {
            string expected = "1234";
            var number = WaggonNumber.CreateNew(expected);
            string actual = number.Identifier;

            Assert.IsNotNull(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WaggonNumberTest_Equals_AreEqual()
        {
            WaggonNumber expected = new WaggonNumber("1234");
            WaggonNumber actual = new WaggonNumber("1234");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WaggonNumberTest_Equals_AreNotEqual()
        {
            WaggonNumber expected = new WaggonNumber("1234");
            WaggonNumber actual = new WaggonNumber("4321");

            Assert.AreNotEqual(expected, actual);
        }

    }
}
