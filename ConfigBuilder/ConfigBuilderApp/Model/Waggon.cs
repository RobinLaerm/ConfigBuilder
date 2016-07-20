using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// Represents a waggon. It contains all necessary informations about a waggon
    /// like number, type, devices, subsystems, etc.
    /// It is the root object for waggons.
    /// </summary>
    public class Waggon
    {
        private List<WaggonType> m_WaggonTypes;

        public Waggon(WaggonNumber number)
        {
            this.WaggonNumber = number;
            this.m_WaggonTypes = new List<WaggonType>();
            this.WaggonTypes = m_WaggonTypes;
        }

        public WaggonNumber WaggonNumber { get; private set; }
        public string IPMask { get; set; }
        public string IPGroup { get; set; }
        public IReadOnlyCollection<WaggonType> WaggonTypes { get; private set; }


        public void AddWaggonType(WaggonType waggonType)
        {
            if (waggonType == null) throw new ArgumentNullException("waggonType");
            this.m_WaggonTypes.Add(waggonType);
        }

        public WaggonType GetWaggonType(string typeName, string usage)
        {
            return m_WaggonTypes.First(wt => wt.Name.Equals(typeName) && wt.Usage.Name.Equals(usage));
        }

        public void RemoveWaggonType(string typeName, string usage)
        {
            var waggonType = GetWaggonType(typeName, usage);
            m_WaggonTypes.Remove(waggonType);
        }

    }
}
