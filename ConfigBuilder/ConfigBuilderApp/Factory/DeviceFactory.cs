using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Factory
{
    public class DeviceFactory
    {
        private static Dictionary<string, Type> m_DeviceTypes = new Dictionary<string, Type>();

        public static void RegisterDeviceType(string typeName, Type type)
        {
            m_DeviceTypes.Add(typeName, type);
        }

        public static List<string> GetPossibleDeviceTypes()
        {
            return m_DeviceTypes.Keys.ToList();
        }

        public static Device CreateNew(string deviceType)
        {
            Type typeToCreate = m_DeviceTypes[deviceType];
            return Activator.CreateInstance(typeToCreate) as Device;
        }
    }
}
