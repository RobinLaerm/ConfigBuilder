using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class WaggonTypeWithUsage
    {
        public WaggonTypeWithUsage(string waggonTypeName, string usageName)
        {
            this.WaggonTypeName = waggonTypeName;
            this.UsageName = usageName;
        }

        public string WaggonTypeName { get; set; }

        public string UsageName { get; set; }

        public override bool Equals(object obj)
        {
            WaggonTypeWithUsage wtwu = obj as WaggonTypeWithUsage;
            if (wtwu == null) return false;
            return
                WaggonTypeName.Equals(wtwu.WaggonTypeName) &&
                UsageName.Equals(wtwu.UsageName);
        }

        public override int GetHashCode()
        {
            return WaggonTypeName.GetHashCode() ^ UsageName.GetHashCode();
        }
    }
}
