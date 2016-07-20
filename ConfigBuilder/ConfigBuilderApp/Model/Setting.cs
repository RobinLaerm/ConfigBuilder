using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// This class is used for global settings that can be stored as key value pair.
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Creates an immutable instance.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Setting(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// The unique identifier of this instance.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// The value for this setting.
        /// </summary>
        public string Value { get; private set; }

        public override bool Equals(object obj)
        {
            Setting setting = obj as Setting;
            if (setting == null) return false;
            return this.Key.Equals(setting.Key);
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }
    }
}
