using System.Collections.Generic;
using br.com.maplink.calculorota.common.integration.CalculoRota;

namespace br.com.maplink.calculorota.common.integration
{
    public class CalculoRotaWrapper : BaseIntegration
    {
        private readonly CalculoRota.CalculoRotaClient _client;

        public CalculoRotaWrapper()
        {
            _client = new CalculoRotaClient();
        }

        public ResultadoCalculo CalcularRotaMaisRapida(List<DadosEntrada> d)
        {
            return _client.CalcularRotaMaisRapida(d.ToArray());
        }

        public ResultadoCalculo CalcularRotaEvitandoTransito(List<DadosEntrada> d)
        {
            return _client.CalcularRotaEvitandoTransito(d.ToArray());
        }
    }
}
