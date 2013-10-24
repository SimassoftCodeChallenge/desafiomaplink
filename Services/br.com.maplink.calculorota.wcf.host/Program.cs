using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using br.com.maplink.calculorota.common.wcf;

namespace br.com.maplink.calculorota.wcf.host
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Config.IsConsoleMode)
            {
                foreach (var sc in Config.GetServiceConfigList())
                {
                    Console.WriteLine(sc.Item.Key);
                    Console.WriteLine("{0}: {1}", "HostTypeDeclaration", sc.Item.HostTypeDeclaration);
                    Console.WriteLine("{0}: {1}", "HostTypeFullname", sc.Item.HostTypeFullname);
                    Console.WriteLine("{0}: {1}", "HostTypeAssembly", sc.Item.HostTypeAssembly);
                    Console.WriteLine("{0}: {1}", "ContractTypeDeclaration", sc.Item.ContractTypeDeclaration);
                    Console.WriteLine("{0}: {1}", "ContractTypeFullname", sc.Item.ContractTypeFullname);
                    Console.WriteLine("{0}: {1}", "ContractTypeAssembly", sc.Item.ContractTypeAssembly);
                    Console.WriteLine("{0}: {1}", "ServiceAddressPort", sc.Item.ServiceAddressPort);
                    Console.WriteLine("{0}: {1}", "EndpointName", sc.Item.EndpointName);
                    Console.WriteLine("{0}: {1}", "AuthorizedGroups", sc.Item.AuthorizedGroups);
                    Console.WriteLine("");
                }

                ServiceRunner sr = new ServiceRunner();
                sr.Start(args);
                Console.WriteLine("WcfServiceHost started... Hit enter to stop...");
                Console.ReadLine();
                sr.Stop();
            }
            else
            {
                //Run it as a service
                ServiceBase[] servicesToRun;
                try
                {
                    servicesToRun = new ServiceBase[] { new WcfService() };
                    ServiceBase.Run(servicesToRun);
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
