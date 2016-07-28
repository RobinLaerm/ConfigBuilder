using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// Represents a waggon.
    /// </summary>
    public class Waggon
    {
        private List<WaggonTypeWithUsage> m_WaggonTypeWithUsageList;

        public Waggon(string identifier)
        {
            this.Identifier = identifier;
            this.WaggonTypeWithUsageList = m_WaggonTypeWithUsageList = new List<WaggonTypeWithUsage>();
        }

        public string Identifier { get; private set; }
        public string IPMask { get; set; }
        public string IPGroup { get; set; }

        public IReadOnlyCollection<WaggonTypeWithUsage> WaggonTypeWithUsageList { get; private set; }

        public void AddWaggonTypeWithUsageList(WaggonTypeWithUsage waggonTypeWithUsage)
        {
            if (waggonTypeWithUsage == null) throw new ArgumentNullException("waggonTypeWithUsage");
            if (m_WaggonTypeWithUsageList.Contains(waggonTypeWithUsage)) throw new InvalidOperationException("There is already a WaggonTypeWithUsage with the same waggon type and usage in internal list.");
            m_WaggonTypeWithUsageList.Add(waggonTypeWithUsage);
        }

        public WaggonTypeWithUsage GetWaggonTypeWithUsage(string waggonTypeName, string usageName)
        {
            return m_WaggonTypeWithUsageList.First(w => w.WaggonTypeName.Equals(waggonTypeName) && w.UsageName.Equals(usageName));
        }

        public void RemoveWaggonTypeWithUsage(string waggonTypeName, string usageName)
        {
            var waggonType = GetWaggonTypeWithUsage(waggonTypeName, usageName);
            m_WaggonTypeWithUsageList.Remove(waggonType);
        }
    }
}
