using ConfigBuilderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Factory
{
    public static class SubsystemFactory
    {
        public static Subsystem Create(string id, string type)
        {
            switch (type)
            {
                case "Relay":
                    {
                        return new SubsystemRelay();
                    }
                case "Explorer":
                    {
                        return new SubsystemExplorer();
                    }
                case "KDR":
                    {
                        return new SubsystemKdr();
                    }
                case "Klima":
                    {
                        return new SubsystemKlima();
                    }
                case "HBU":
                    {
                        return new SubsystemWithIPAddress(type);
                    }
                case "Footboard":
                    {
                        return new SubsystemWithIPAddress(type);
                    }
                default:
                    {
                        return new Subsystem(type);
                    }
            }
        }
    }
}
