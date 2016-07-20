using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// Represents a part of an ip address for a special device like NVR, NAS, etc.
    /// Combined with an IPMask a complete ip address can be generated.
    /// </summary>
    public class PartOfIPAddress
    {
        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="referenceId"></param>
        public PartOfIPAddress(string referenceId) :this(referenceId, "")
        {
        }

        /// <summary>
        /// Creates an instance.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="partOfIP"></param>
        public PartOfIPAddress(string referenceId, string partOfIP)
        {
            this.ReferenceId = referenceId;
            this.Part = partOfIP;
        }


        /// <summary>
        /// The identifier of this instance so this part of an ip address can be referrenced from any other class.
        /// </summary>
        public string ReferenceId { get; private set; }

        /// <summary>
        /// The device specific part of an ip address.
        /// <code>
        /// "x.x.x.150"
        /// </code>
        /// </summary>
        public string Part { get; set; }

        public override bool Equals(object obj)
        {
            PartOfIPAddress partOfIP = obj as PartOfIPAddress;
            if (partOfIP == null) return false;
            return
                this.ReferenceId.Equals(partOfIP.ReferenceId);
        }

        public override int GetHashCode()
        {
            return
                this.ReferenceId.GetHashCode();
        }
    }
}
