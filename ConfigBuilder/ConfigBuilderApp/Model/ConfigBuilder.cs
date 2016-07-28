using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigBuilderApp.Model
{
    /// <summary>
    /// Contains all necessary configuration objects to build up the configuration for a whole waggon.
    /// </summary>
    public class ConfigBuilder
    {
        private List<Setting> m_Settings;
        private List<PartOfIPAddress> m_IPAddresses;
        private List<Waggon> m_Waggons;

        public ConfigBuilder()
        {
            Settings = m_Settings = new List<Setting>();
            IPAddresses = m_IPAddresses = new List<PartOfIPAddress>();
            Waggons = m_Waggons = new List<Waggon>();
        }

        public string TemplatesFolder { get; set; }
        public string TempFolder { get; set; }
        public string BatchFolder { get; set; }
        public string ConfigurationInfoFilePath { get; set; }

        /// <summary>
        /// List of global settings.
        /// </summary>
        public IReadOnlyCollection<Setting> Settings { get; private set; }

        /// <summary>
        /// List with part of ip addresses that will be referenced by devices.
        /// </summary>
        public IReadOnlyCollection<PartOfIPAddress> IPAddresses { get; private set; }
        /// <summary>
        /// List of waggons that are configured within the configuration.
        /// </summary>
        public IReadOnlyCollection<Waggon> Waggons { get; private set; }

        /// <summary>
        /// Adds a setting to the list of settings.
        /// </summary>
        /// <param name="setting"></param>
        public void AddSetting(Setting setting)
        {
            if (setting == null) throw new ArgumentNullException("setting");
            m_Settings.Add(setting);
        }

        /// <summary>
        /// Returns an existing setting.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Setting GetSetting(string key)
        {
            return m_Settings.First(s => s.Key.Equals(key));
        }

        /// <summary>
        /// Removes an existing setting.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveSetting(string key)
        {
            Setting setting = GetSetting(key);
            m_Settings.Remove(setting);
        }

        public void AddIPAddress(PartOfIPAddress address)
        {
            if (address == null) throw new ArgumentNullException("address");
            if (m_IPAddresses.Contains(address)) throw new InvalidOperationException(string.Format("An instance of PartOfIPAddress is already in list. [{0}]", address));
            m_IPAddresses.Add(address);
        }

        public PartOfIPAddress GetIPAddress(string referenceId)
        {
            return m_IPAddresses.First((ip) => ip.ReferenceId.Equals(referenceId));
        }

        public void RemoveIPAddress(string referenceId)
        {
            PartOfIPAddress address = GetIPAddress(referenceId);
            m_IPAddresses.Remove(address);
        }


        /// <summary>
        /// Adds a waggon into the internal list of waggons.
        /// </summary>
        /// <param name="waggon"></param>
        public void AddWaggon(Waggon waggon)
        {
            if (waggon == null) throw new ArgumentNullException("waggon");
            if (this.Waggons.FirstOrDefault((w) => w.Identifier.Equals(waggon.Identifier)) != null)
                throw new InvalidOperationException(string.Format("Waggon with identifier {0} already exists in internal list.", waggon.Identifier));
            this.m_Waggons.Add(waggon);
        }

        /// <summary>
        /// Returns the waggon for the given identifier.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public Waggon GetWaggon(string identifier)
        {
            return this.Waggons.First((w) => w.Identifier.Equals(identifier, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Removes the waggon with the given identifier from internal list.
        /// </summary>
        /// <param name="identifier"></param>
        public void RemoveWaggon(string identifier)
        {
            var waggon = GetWaggon(identifier);
            this.m_Waggons.Remove(waggon);
        }
    }
}
