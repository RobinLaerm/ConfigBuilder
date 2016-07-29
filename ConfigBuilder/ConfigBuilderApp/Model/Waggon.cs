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
        private List<string> m_UsageNames;

        public Waggon(string identifier)
        {
            this.Identifier = identifier;
            this.UsageNames = m_UsageNames = new List<string>();
        }

        public string Identifier { get; private set; }
        public string IPMask { get; set; }
        public string IPGroup { get; set; }
        public string TypeName { get; set; }
        public IReadOnlyCollection<string> UsageNames { get; private set; }

        #region UsageName functions
        public void AddUsageName(string usageName)
        {
            if (string.IsNullOrEmpty(usageName)) throw new ArgumentNullException("usageName");
            if (m_UsageNames.Contains(usageName)) throw new InvalidOperationException("There is already an usage with the same name in internal list.");
            m_UsageNames.Add(usageName);
        }

        public void RemoveUsageName(string usageName)
        {
            if (m_UsageNames.Contains(usageName) == false) throw new InvalidOperationException("There is no usage with the given name in internal list.");
            m_UsageNames.Remove(usageName);
        }
        #endregion

    }
}
