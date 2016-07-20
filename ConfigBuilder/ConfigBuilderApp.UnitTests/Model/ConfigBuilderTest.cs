using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;
using System.Collections.Generic;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class ConfigBuilderTest
    {
        [TestMethod]
        public void AddWaggon_AddNewWaggonToEmptyConfiguration_WaggonDoesExistInWaggonList()
        {
            string waggonIdentifier = "111111-222222-3";
            ConfigBuilder configuration = new ConfigBuilder();
            Waggon waggon = CreateFakeWaggon(waggonIdentifier);
            configuration.AddWaggon(waggon);
            int waggonCount = configuration.Waggons.Count;
            Assert.IsTrue(waggonCount == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddWaggon_AddWaggonWithSameIdentifierTwice_InvalidOperationException()
        {
            ConfigBuilder configuration = new ConfigBuilder();
            Waggon waggonOne = CreateFakeWaggon("1234");
            Waggon waggonTwo = CreateFakeWaggon("1234");
            configuration.AddWaggon(waggonOne);
            configuration.AddWaggon(waggonTwo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWaggon_AddNull_ArgumentNullException()
        {
            ConfigBuilder configuration = new ConfigBuilder();
            configuration.AddWaggon(null);
        }

        [TestMethod]
        public void GetWaggon_GetWaggonThatDoesExist_WaggonWillBeReturned()
        {
            string identifier = "111111-11111-1";
            ConfigBuilder configuration = CreateFakeConfigBuilderWithSomeValues();
            string actual = configuration.GetWaggon(identifier).WaggonNumber.Identifier;
            Assert.AreEqual(identifier, actual);
        }

        [TestMethod]
        public void RemoveWaggon_ExistingWaggon_WaggonIsNotInListAnyLonger()
        {
            ConfigBuilder configuration = CreateFakeConfigBuilderWithSomeValues();
            int expectedCount = configuration.Waggons.Count - 1;
            configuration.RemoveWaggon("111111-11111-1");
            int actualCount = configuration.Waggons.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void AddSetting_NewSetting_SettingIsInList()
        {
            Setting expected = new Setting("Key", "Value");
            ConfigBuilder builder = CreateFakeConfigBuilder();
            builder.AddSetting(expected);
            Setting actual = builder.GetSetting(expected.Key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveSetting_RemoveSettingFromList_SettingIsNotInList()
        {
            ConfigBuilder builder = CreateFakeConfigBuilderWithSomeValues();
            int expected = builder.Settings.Count - 1;
            builder.RemoveSetting("Key1");
            int actual = builder.Settings.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddIPAddress_NewPartOfIPAddress_IPAddressIsInList()
        {
            PartOfIPAddress expected = new PartOfIPAddress("100", "x.x.x.100");
            ConfigBuilder builder = CreateFakeConfigBuilder();
            builder.AddIPAddress(expected);
            PartOfIPAddress actual = builder.GetIPAddress(expected.ReferenceId);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveIPAddress_RemoveIPAddressFromList_IPAddressIsNotInList()
        {
            ConfigBuilder builder = CreateFakeConfigBuilderWithSomeValues();
            int expected = builder.IPAddresses.Count - 1;
            builder.RemoveIPAddress("1");
            int actual = builder.IPAddresses.Count;

            Assert.AreEqual(expected, actual);
        }



        private ConfigBuilder CreateFakeConfigBuilder()
        {
            ConfigBuilder builder = new ConfigBuilder();
            return builder;
        }

        private Waggon CreateFakeWaggon(string identifier)
        {
            Waggon waggon = new Waggon(new WaggonNumber(identifier));
            return waggon;
        }

        private ConfigBuilder CreateFakeConfigBuilderWithSomeValues()
        {
            ConfigBuilder configBuilder = new ConfigBuilder();
            configBuilder.AddWaggon(CreateFakeWaggon("111111-11111-1"));
            configBuilder.AddWaggon(CreateFakeWaggon("222222-22222-2"));
            configBuilder.AddWaggon(CreateFakeWaggon("333333-33333-3"));
            configBuilder.AddSetting(new Setting("Key1", "Value1"));
            configBuilder.AddSetting(new Setting("Key2", "Value2"));
            configBuilder.AddSetting(new Setting("Key3", "Value3"));
            configBuilder.AddIPAddress(new PartOfIPAddress("1", "x.x.x.1"));
            configBuilder.AddIPAddress(new PartOfIPAddress("2", "x.x.x.2"));
            configBuilder.AddIPAddress(new PartOfIPAddress("3", "x.x.x.3"));
            return configBuilder;
        }

    }
}
