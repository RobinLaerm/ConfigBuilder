using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class Camera : Device
    {
        public Camera(string id) : base(id, "Camera")
        {
        }

        /// <summary>
        /// The name of this camera.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cameras can be organized in groups like "Außenkamera", "Innenkamera", "Rückspiegelkamera", etc.
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// The type of the camera like "M3113", "P3904", etc.
        /// </summary>
        public string CameraType { get; set; }

    }
}
