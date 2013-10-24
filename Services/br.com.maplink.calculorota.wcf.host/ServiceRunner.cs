using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using br.com.maplink.calculorota.common.wcf;

namespace br.com.maplink.calculorota.wcf.host
{
    internal class ServiceRunner
    {
        List<ServiceHost> serviceHosts = new List<ServiceHost>();

        public void Start(string[] args)
        {
            try
            {
                //Add code that will execute on start.
                foreach (var sc in Config.GetServiceConfigList())
                {
                    ServiceHost host = sc.Item.CreateServiceHost();
                    if (host != null)
                    {
                        host.Open(); //open host to listen for connection clients
                        serviceHosts.Add(host);
                    }
                }
            }
            catch (Exception e)
            {
                //do your exception handling thing
                e.ProcessUnhandledException("WcfServiceHost");
            }
        }

        public void Stop()
        {
            //Add code that will execute on stop.
            foreach (var host in serviceHosts)  //stop services
            {
                if (host != null)
                {
                    try
                    {
                        host.Close();
                    }
                    catch (Exception e)
                    {
                        //do your exception handling thing
                        e.ProcessUnhandledException("WcfServiceHost");
                    }
                }
            }
        }
    }
}
