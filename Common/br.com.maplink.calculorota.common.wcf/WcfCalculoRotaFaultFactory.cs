using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace br.com.maplink.calculorota.common.wcf
{
    public static class WcfCalculoRotaFaultFactory
    {
        public static FaultException<WcfCalculoRotaFault> CreateWcfServiceFault(Exception ex)
        {
            return new FaultException<WcfCalculoRotaFault>(new WcfCalculoRotaFault(ex.Message, ex), new FaultReason(ex.Message));
        }
    }
}
