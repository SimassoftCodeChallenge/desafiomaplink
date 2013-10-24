using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Services.Protocols;

namespace br.com.maplink.calculorota.common.integration
{
    public abstract class BaseIntegration
    {
        protected string _token = string.Empty;
        private string _proxy_user = string.Empty;
        private string _proxy_pass = string.Empty;
        private string _proxy_domain = string.Empty;

        protected BaseIntegration()
        {
            _token = config.ConfigWrapper.GetAppSetting("token");
            _proxy_user = config.ConfigWrapper.GetAppSetting("proxy_user");
            _proxy_pass = config.ConfigWrapper.GetAppSetting("proxy_pass");
            _proxy_domain = config.ConfigWrapper.GetAppSetting("proxy_domain");

        }

        protected void ConfigureProxy(SoapHttpClientProtocol _client)
        {
            if (config.ConfigWrapper.GetAppSetting("proxy") != null)
            {
                _client.UseDefaultCredentials = false;
                _client.PreAuthenticate = true;

                _client.Proxy = new WebProxy(config.ConfigWrapper.GetAppSetting("proxy"), true);
                _client.Proxy.Credentials = new NetworkCredential(_proxy_user,
                                                                  _proxy_pass,
                                                                  _proxy_domain);

            }
        }
    }
}
