using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class SettingTest
    {
        [TestMethod]
        public void Setting_CreateInstanceWithKeyAndValue_InstanceIsCorrectInitialized()
        {
            string key = "MyKey";
            string value = "MyValue";
            Setting setting = new Setting(key, value);

            Assert.AreEqual(key, setting.Key);
            Assert.AreEqual(value, setting.Value);
        }

        [TestMethod]
        public void Setting_CompareTwoInstancesThatAreEqual_InstanceAreEqual()
        {
            Setting setting1 = new Setting("1", "value");
            Setting setting2 = new Setting("1", "value");

            Assert.AreEqual(setting1, setting2);
        }

        [TestMethod]
        public void Setting_CompareTwoInstancesThatAreNotEqual_InstanceAreNotEqual()
        {
            Setting setting1 = new Setting("1", "value");
            Setting setting2 = new Setting("2", "value");

            Assert.AreNotEqual(setting1, setting2);
        }

    }
}
