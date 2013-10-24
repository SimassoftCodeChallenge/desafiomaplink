using System;
using System.Configuration;
using System.Reflection;
using br.com.maplink.calculorota.common.errorlog;

namespace br.com.maplink.calculorota.common.config
{
    public static class ConfigWrapper
    {
        private static Configuration config = null;

        static ConfigWrapper()
        {
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            catch (Exception ex)
            {
                new ErrorLogHelper().Log(ex);
            }
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
            catch (NullReferenceException)
            {
                if (returnNameIfNotFound)
                    return name;
                else
                    return null;
            }
            catch (IndexOutOfRangeException)
            {
                if (returnNameIfNotFound)
                    return name;
                else
                    return null;
            }
        }
    }
}
