using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    public class WaggonType
    {
        /// <summary>
        /// Creates an immutable instance that combines a waggonType with a usage.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="usage"></param>
        public WaggonType(string typeName, Usage usage)
        {
            this.Name = typeName;
            this.Usage = usage;
        }

        /// <summary>
        /// The name of the waggon type.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The specific usage this waggon type is for.
        /// </summary>
        public readonly Usage Usage;

        public override bool Equals(object obj)
        {
            WaggonType waggonType = obj as WaggonType;
            if (waggonType == null) return false;
            return this.Name.Equals(waggonType.Name)
                && this.Usage.Equals(waggonType.Usage);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() | this.Usage.GetHashCode();
        }
    }
}
