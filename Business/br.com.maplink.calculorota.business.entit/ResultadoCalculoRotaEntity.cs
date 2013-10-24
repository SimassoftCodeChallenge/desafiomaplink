using System;

namespace br.com.maplink.calculorota.business.entities
{
    public class ResultadoCalculoRotaEntity
    {
        public TimeSpan TempoTotalRota { get; set; }

        public long DistanciaTotalRota { get; set; }

        public decimal CustoTotalCombustivel { get; set; }

        public decimal CustoTotalPedagio { get; set; }
    }
}
