using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
    public class WcfServiceClient<TClient> : ClientBase<TClient>, IDisposable where TClient : class
    {
        public static WcfServiceClient<TClient> Create(string key)
        {
            Type clientType = typeof(TClient);
            var configItem = Config.GetServiceConfig(clientType);
            if (null != configItem)
            {
                NetTcpBinding tcpBinding = TcpBindingUtility.CreateNetTcpBinding();
                EndpointAddress endpointAddress = TcpBindingUtility.CreateEndpointAddress(
                    configItem.Item.ServiceAddressPort + "/" + configItem.Item.EndpointName);

                WcfServiceClient<TClient> client = new WcfServiceClient<TClient>(tcpBinding, endpointAddress);
                return client;
            }
            throw new Exception("Type " + clientType.AssemblyQualifiedName + " not found.");
        }

        internal WcfServiceClient() { }

        internal WcfServiceClient(string endpointConfigurationName) : base(endpointConfigurationName) { }

        internal WcfServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }

        internal WcfServiceClient(InstanceContext callbackInstance) : base(callbackInstance) { }

        public TClient Instance
        {
            get { return base.Channel; }
        }

        public void Dispose()
        {
            AbortClose();
        }

        public void AbortClose()
        {
            if (this.State != CommunicationState.Closed)
                this.Abort();
            else
                this.Close();
        }

    }
}
