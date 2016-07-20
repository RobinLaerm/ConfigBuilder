using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// The waggon numer is an immutable object that is unique for the waggon.
    /// </summary>
    public class WaggonNumber
    {
        /// <summary>
        /// Creates a new instance of WaggonNumber.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static WaggonNumber CreateNew(string identifier)
        {
            return new WaggonNumber(identifier);
        }

        /// <summary>
        /// Creates a new instance of WaggonNumber.
        /// </summary>
        /// <param name="identifier"></param>
        public WaggonNumber(string identifier)
        {
            this.Identifier = identifier;
        }

        /// <summary>
        /// The unique identifier of a waggon.
        /// </summary>
        public readonly string Identifier;

        public override bool Equals(object obj)
        {
            var waggonNumber = obj as WaggonNumber;
            if (waggonNumber == null) return false;
            return this.Identifier.Equals(waggonNumber.Identifier);
        }

        public override int GetHashCode()
        {
            return this.Identifier.GetHashCode();
        }
    }
}
