using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigBuilderApp.Model;

namespace ConfigBuilderApp.UnitTests.Model
{
    [TestClass]
    public class CameraTest
    {
        [TestMethod]
        public void CameraCtor_CreateNewCamera_CameraCorrectInitialized()
        {
            Camera camera = new Camera("1");

            Assert.AreEqual("1", camera.Id);
            Assert.AreEqual("Camera", camera.Type);
        }

        [TestMethod]
        public void CameraCtor_SetProperties_PropertiesAreSet()
        {
            Camera camera = new Camera("1");
            camera.Name = "MyCamera1";
            camera.PartOfIPAddress = new PartOfIPAddress("Camera01", "x.x.x.11");

            Assert.AreEqual("MyCamera1", camera.Name);
            Assert.AreEqual("Camera01", camera.PartOfIPAddress.ReferenceId);
            Assert.AreEqual("x.x.x.11", camera.PartOfIPAddress.Part);
        }


    }
}
