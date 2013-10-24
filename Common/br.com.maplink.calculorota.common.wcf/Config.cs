using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
    public static class Config
    {
        static Configuration config = null;
        static Config()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public static string GetAppSetting(string name)
        {
            return GetAppSetting(name, false);
        }

        public static string GetAppSetting(string name, bool returnNameIfNotFound)
        {
            try
            {
                return config.AppSettings.Settings[name].Value;
            }
            catch (IndexOutOfRangeException)
            {
                if (returnNameIfNotFound)
                    return name;
                else
                    return null;
            }
        }

        static object lob = new object();
        static WcfServiceConfigurationSection wcfServices = null;
        static Dictionary<Type, ServiceConfig> wcfServiceConfigByType = new Dictionary<Type, ServiceConfig>();
        static Dictionary<string, ServiceConfig> wcfServiceConfigByKey = new Dictionary<string, ServiceConfig>();

        static void InitializeConfig()
        {
            wcfServices = (WcfServiceConfigurationSection)ConfigurationManager.GetSection("wcfServices");
            foreach (WcfServiceConfigElement item in wcfServices.Services)
            {
                Type hostType = Type.GetType(item.HostTypeDeclaration);
                Type contractType = Type.GetType(item.ContractTypeDeclaration);
                var configItem = new ServiceConfig { Item = item, HostType = hostType, ContractType = contractType };

                if (hostType != null && !wcfServiceConfigByType.ContainsKey(hostType))
                    wcfServiceConfigByType.Add(hostType, configItem);

                if (contractType != null && !wcfServiceConfigByType.ContainsKey(contractType))
                    wcfServiceConfigByType.Add(contractType, configItem);

                if (!wcfServiceConfigByKey.ContainsKey(item.Key))
                    wcfServiceConfigByKey.Add(item.Key, configItem);
            }
        }

        public static bool IsConsoleMode
        {
            get
            {
                if (wcfServices == null) InitializeConfig();
                return wcfServices.IsConsoleMode;
            }
        }

        public static ServiceConfig GetServiceConfig(Type type)
        {
            lock (lob)
            {
                if (wcfServices == null) InitializeConfig();
                if (wcfServiceConfigByType.ContainsKey(type))
                    return wcfServiceConfigByType[type];
                else
                    return null;
            }
        }

        public static ServiceConfig GetServiceConfig(string key)
        {
            lock (lob)
            {
                if (wcfServices == null) InitializeConfig();
                if (wcfServiceConfigByKey.ContainsKey(key))
                    return wcfServiceConfigByKey[key];
                else
                    return null;
            }
        }

        public static List<ServiceConfig> GetServiceConfigList()
        {
            lock (lob)
            {
                if (wcfServices == null) InitializeConfig();
                return wcfServiceConfigByKey.Values.ToList();
            }
        }
    }

    public class ServiceConfig
    {
        public Type HostType { get; set; }
        public Type ContractType { get; set; }
        public WcfServiceConfigElement Item { get; set; }
    }
}
