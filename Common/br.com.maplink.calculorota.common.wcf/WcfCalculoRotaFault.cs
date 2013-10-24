using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
    [DataContract]
    public class WcfCalculoRotaFault : WcfServiceFault
    {
        public string SrcMessage { get; set; }

        public WcfCalculoRotaFault(string message, Exception inner)
        {
            this.Message = message;
            this.Inner = inner;
        }
    }
}
