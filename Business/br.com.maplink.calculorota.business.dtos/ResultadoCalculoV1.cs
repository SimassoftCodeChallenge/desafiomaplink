using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace br.com.maplink.calculorota.business.dtos
{
    [DataContract(Namespace = "http://maplink.com.br/CalculoRota/V1/ResultadoCalculo", Name = "ResultadoCalculo")]
    public class ResultadoCalculoV1 : IResultadoCalculoV1
    {
        [DataMember]
        public TimeSpan TempoTotalRota { get; set; }

        [DataMember]
        public long DistanciaTotalRota { get; set; }

        [DataMember]
        public decimal CustoTotalCombustivel { get; set; }

        [DataMember]
        public decimal CustoTotalPedagio { get; set; }
    }



    public interface IResultadoCalculoV1
    {
        TimeSpan TempoTotalRota { get; set; }
        long DistanciaTotalRota { get; set; }
        decimal CustoTotalCombustivel { get; set; }
        decimal CustoTotalPedagio { get; set; }
    }
}
