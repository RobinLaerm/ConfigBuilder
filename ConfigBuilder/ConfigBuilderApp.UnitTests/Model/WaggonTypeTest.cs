﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class WaggonTypeTest
    {
        [TestMethod]
        public void WaggonType_Ctor_WaggonTypeNameIsLikeExpected()
        {
            string expected = "R1234";
            string usage = "Video";
            WaggonType waggonType = new WaggonType(expected, usage);
            string actual = waggonType.Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WaggonType_Equals_AreEqual()
        {
            string waggonTypeName = "R1234";
            string usage = "Video";
            WaggonType wt1 = new WaggonType(waggonTypeName, usage);
            WaggonType wt2 = new WaggonType(waggonTypeName, usage);

            Assert.AreEqual(wt1, wt2);
        }

        [TestMethod]
        public void WaggonType_EqualsWithDifferentWaggonTypes_AreNotEqual()
        {
            string waggonTypeName1 = "R1234";
            string waggonTypeName2 = "R4321";
            string usage = "Video";
            WaggonType wt1 = new WaggonType(waggonTypeName1, usage);
            WaggonType wt2 = new WaggonType(waggonTypeName2, usage);

            Assert.AreNotEqual(wt1, wt2);
        }

        [TestMethod]
        public void WaggonType_EqualsWithDifferentUsages_AreNotEqual()
        {
            string waggonTypeName = "R1234";
            string usage1 = "Video";
            string usage2 = "Diagnose";
            WaggonType wt1 = new WaggonType(waggonTypeName, usage1);
            WaggonType wt2 = new WaggonType(waggonTypeName, usage2);

            Assert.AreNotEqual(wt1, wt2);
        }

    }
}
