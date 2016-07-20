using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// Represents an ip mask with placeholders.
    /// <code>
    /// IPMask mask = new IPMask("10.x.x.x");
    /// IPMask mask = new IPMask("10.20.x.x");
    /// IPMask mask = new IPMask("10.20.30.x");
    /// </code>
    /// </summary>
    public class IPMask
    {
        /// <summary>
        /// Combines two strings to a valid ip address.
        /// The mask and the part of the ip address have to match.
        /// There is no further validation if the ip address is valid or not.
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="partOfIPAddress"></param>
        /// <returns></returns>
        public static string Combine(string mask, string partOfIPAddress)
        {
            string firstPartOfIP = mask;
            int firstIndexOfPlaceholder = mask.IndexOf("x");
            if (firstIndexOfPlaceholder >= 0)
                firstPartOfIP = mask.Substring(0, firstIndexOfPlaceholder);
            string secondPartOfIP = partOfIPAddress;
            int lastIndexOfPlaceholder = partOfIPAddress.LastIndexOf("x");
            if (lastIndexOfPlaceholder >= 0)
                secondPartOfIP = partOfIPAddress.Substring(lastIndexOfPlaceholder + 2);
            return firstPartOfIP + secondPartOfIP;
        }

        /// <summary>
        /// Creates a new instance with the given ip mask.
        /// </summary>
        /// <param name="mask"></param>
        public IPMask(string mask)
        {
            Mask = mask;
        }

        /// <summary>
        /// Returns the ip mask.
        /// </summary>
        public string Mask { get; private set; }

        /// <summary>
        /// Uses the static Combine method to combine the mask of this instance with the given parameter.
        /// </summary>
        /// <param name="partOfIPAddress"></param>
        /// <returns></returns>
        public string Combine(string partOfIPAddress)
        {
            return Combine(Mask, partOfIPAddress);
        }

    }

}
