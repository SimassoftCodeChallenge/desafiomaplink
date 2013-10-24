using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
    public static class WcfExtensions
    {
        public static ServiceHost CreateServiceHost(this WcfServiceConfigElement item)
        {
            //start service listener
            if (string.IsNullOrEmpty(item.ServiceAddressPort) || string.IsNullOrEmpty(item.EndpointName)) return null; //no launch will occur if config is not there

            Type hostType = Type.GetType(item.HostTypeDeclaration);
            Type contractType = Type.GetType(item.ContractTypeDeclaration);

            Uri tcpBaseAddress = new Uri(string.Format("net.tcp://{0}/", item.ServiceAddressPort));
            ServiceHost host = new ServiceHost(hostType, tcpBaseAddress);

            NetTcpBinding tcpBinding = TcpBindingUtility.CreateNetTcpBinding();
            //tcpBinding.PortSharingEnabled = true;

            //Metada
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();

            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            smb.HttpGetEnabled = false;

            host.Description.Behaviors.Add(smb);

            //Metada
            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                        MetadataExchangeBindings.CreateMexTcpBinding(),
                        string.Format("net.tcp://{0}/{1}/mex",
                        item.ServiceAddressPort,
                        item.EndpointName));

            //Service
            host.AddServiceEndpoint(contractType, 
                                    tcpBinding,
                                    string.Format("net.tcp://{0}/{1}", 
                                    item.ServiceAddressPort, 
                                    item.EndpointName));

            //this is the default but good to know
            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseWindowsGroups;

            return host;
        }
    }

    public class TcpBindingUtility
    {
        /// <summary>
        /// Client: maximum connections to be pooled for reuse.
        /// Server: maximum connections allowed to be pending dispatch.
        /// </summary>
        public static Int32 MaxConnections { get; private set; }

        /// <summary>
        /// The default is 65,536 bytes.
        /// </summary>
        public static Int64 MaxReceivedMessageSize { get; private set; }

        /// <summary>
        /// The default is 65,536 bytes
        /// </summary>
        public static Int64 MaxBufferPoolSize { get; private set; }

        public static TimeSpan OpenTimeout { get; private set; }
        public static TimeSpan CloseTimeout { get; private set; }
        public static TimeSpan ReceiveTimeout { get; private set; }
        public static TimeSpan SendTimeout { get; private set; }


        /// <summary>
        /// Static initializer for default values in each build configuration.
        /// </summary>
        static TcpBindingUtility()
        {
#if(DEBUG)
            MaxConnections = 10;
            MaxReceivedMessageSize = 4194304;				// 4MB The default is 65,536 bytes
            MaxBufferPoolSize = 1048576;					// 1MB default is 65,536 bytes
            OpenTimeout = new TimeSpan(0, 20, 0);
            CloseTimeout = new TimeSpan(0, 20, 0);
            ReceiveTimeout = new TimeSpan(0, 20, 0);
            SendTimeout = new TimeSpan(0, 20, 0);
#else
			MaxConnections = 10;
			MaxReceivedMessageSize = 4194304;				// 4MB The default is 65,536 bytes
			MaxBufferPoolSize = 1048576;					// 1MB default is 65,536 bytes
			OpenTimeout = new TimeSpan(0, 1, 30);
			CloseTimeout = new TimeSpan(0, 1, 30);
			ReceiveTimeout = new TimeSpan(0, 10, 0);
			SendTimeout = new TimeSpan(0, 1, 30);
#endif
        }


        public static NetTcpBinding CreateNetTcpBinding()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.Transport, false);

            tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            tcpBinding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;

            tcpBinding.MaxConnections = MaxConnections;
            tcpBinding.MaxReceivedMessageSize = MaxReceivedMessageSize;
            tcpBinding.MaxBufferPoolSize = MaxBufferPoolSize;
            //not allowed by partially trusted 
            //tcpBinding.MaxBufferSize = 262144;							//256KB default is 65,536 bytes

            tcpBinding.OpenTimeout = OpenTimeout;
            tcpBinding.CloseTimeout = CloseTimeout;
            tcpBinding.ReceiveTimeout = ReceiveTimeout;
            tcpBinding.SendTimeout = SendTimeout;

            return tcpBinding;
        }

        public static EndpointAddress CreateEndpointAddress(string serviceAddress)
        {
            return new EndpointAddress(string.Format("net.tcp://{0}", serviceAddress));
        }
    }
}
