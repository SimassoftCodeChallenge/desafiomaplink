using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
    /*		<wcfServices consoleMode="On">
        <services>
            <add key="test1" 
                  serviceAddressPort="localhost:2981" 
                  endpointName="Test1EndPoint" 
                  authorizedGroups="WcfServiceClients" 
                  hostType="Test1Service.MyService, Test1Service"
                  contractType="Test1Common.IMyService, Test1Common" />
            <add key="test2" 
                  serviceAddressPort="localhost:2981" 
                  endpointName="Test2EndPoint" 
                  authorizedGroups="WcfServiceClients" 
                  hostType="Test2Service.MyService, Test2Service"
                  contractType="Test2Common.IMyService, Test2Common" />
        </services>
    </wcfServices>
    */
    public class WcfServiceConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("services")]
        public WcfServiceConfigCollection Services
        {
            get
            {
                return ((WcfServiceConfigCollection)(base["services"]));
            }
        }

        //<wcfServices consoleMode="On">
        [ConfigurationProperty("consoleMode", DefaultValue = "On", IsKey = false, IsRequired = true)]
        [RegexStringValidator("^(On|on|Off|off)$")]
        public string ConsoleMode
        {
            get
            { return (string)this["consoleMode"]; }
            set
            { this["consoleMode"] = value; }
        }

        public bool IsConsoleMode
        {
            get
            {
                if (ConsoleMode.ToLower() == "on")
                    return true;
                else
                    return false;
            }
        }
    }

    [ConfigurationCollectionAttribute(typeof(WcfServiceConfigElement))]
    public class WcfServiceConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WcfServiceConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WcfServiceConfigElement)(element)).Key;
        }

        public void Add(WcfServiceConfigElement element)
        {
            this.BaseAdd(element);
        }

        public void Remove(string key)
        {
            this.BaseRemove(key);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        public WcfServiceConfigElement this[int idx]
        {
            get { return (WcfServiceConfigElement)this[idx]; }
        }
    }

    /*		<wcfServices consoleMode="On">
        <services>
            <add key="test1" 
                  serviceAddressPort="localhost:2981" 
                  endpointName="Test1EndPoint" 
                  authorizedGroups="WcfServiceClients" 
                  hostType="Test1Service.MyService, Test1Service"
                  contractType="Test1Common.IMyService, Test1Common" />
            <add key="test2" 
                  serviceAddressPort="localhost:2981" 
                  endpointName="Test2EndPoint" 
                  authorizedGroups="WcfServiceClients" 
                  hostType="Test2Service.MyService, Test2Service"
                  contractType="Test2Common.IMyService, Test2Common" />
        </services>
    </wcfServices>
    */
    public class WcfServiceConfigElement : ConfigurationElement
    {
        public WcfServiceConfigElement() { }
        public WcfServiceConfigElement(string key, string serviceAddressPort, string endpointName,
            string authorizedGroups, string hostType, string contractType)
        {
            this.Key = key;
            this.ServiceAddressPort = serviceAddressPort;
            this.EndpointName = endpointName;
            this.AuthorizedGroups = authorizedGroups;
            this.HostTypeDeclaration = hostType;
            this.ContractTypeDeclaration = contractType;
        }

        [ConfigurationProperty("key", DefaultValue = "_", IsKey = true, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()[]{}/;'\"|\\", MinLength = 1, MaxLength = 260)]
        public string Key
        {
            get
            { return (string)this["key"]; }
            set
            { this["key"] = value; }
        }

        [ConfigurationProperty("serviceAddressPort", DefaultValue = "_", IsKey = false, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()[]{}/;'\"|\\", MinLength = 1, MaxLength = 260)]
        public string ServiceAddressPort
        {
            get
            { return (string)this["serviceAddressPort"]; }
            set
            { this["serviceAddressPort"] = value; }
        }

        [ConfigurationProperty("endpointName", DefaultValue = "_", IsKey = false, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()[]{}/;'\"|\\", MinLength = 1, MaxLength = 260)]
        public string EndpointName
        {
            get
            { return (string)this["endpointName"]; }
            set
            { this["endpointName"] = value; }
        }

        //, string type
        [ConfigurationProperty("authorizedGroups", DefaultValue = "_", IsKey = false, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()[]{}/;'\"|\\", MinLength = 1, MaxLength = 520)]
        public string AuthorizedGroups
        {
            get
            { return (string)this["authorizedGroups"]; }
            set
            { this["authorizedGroups"] = value; }
        }

        [ConfigurationProperty("hostType", DefaultValue = "_", IsKey = false, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()/|\\", MinLength = 1, MaxLength = 520)]
        public string HostTypeDeclaration
        {
            get
            { return (string)this["hostType"]; }
            set
            { this["hostType"] = value; }
        }

        public string HostTypeFullname
        {
            get
            {
                string[] parts = HostTypeDeclaration.Split(',');
                return parts[0].Trim();
            }
        }

        public string HostTypeAssembly
        {
            get
            {
                string[] parts = HostTypeDeclaration.Split(',');
                return (parts.Length > 1)
                    ? parts[1].Trim()
                    : null;
            }
        }

        [ConfigurationProperty("contractType", DefaultValue = "_", IsKey = false, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()/|\\", MinLength = 1, MaxLength = 520)]
        public string ContractTypeDeclaration
        {
            get
            { return (string)this["contractType"]; }
            set
            { this["contractType"] = value; }
        }

        public string ContractTypeFullname
        {
            get
            {
                string[] parts = ContractTypeDeclaration.Split(',');
                return parts[0].Trim();
            }
        }

        public string ContractTypeAssembly
        {
            get
            {
                string[] parts = ContractTypeDeclaration.Split(',');
                return (parts.Length > 1)
                    ? parts[1].Trim()
                    : null;
            }
        }
    }
}
