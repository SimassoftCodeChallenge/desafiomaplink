using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace br.com.maplink.calculorota.common.wcf
{
    [DataContract]
    public abstract class WcfServiceFault
    {
        public Exception Inner { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string Target { get; set; }

        public override string ToString()
        {
            if (null == Inner)
                return string.Format("Target: {0} / Source: {1} / Message: {2}", Target, Source, Message);
            else
                return string.Format("Target: {0} / Source: {1} / Message: {2}{3}/ Inner: {4}", Target, Source, Message, Environment.NewLine, Inner.ToString());
        }
    }
}
