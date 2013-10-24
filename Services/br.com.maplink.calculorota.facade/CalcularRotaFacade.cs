using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.maplink.calculorota.business;
using br.com.maplink.calculorota.business.dtos;
using br.com.maplink.calculorota.data;

namespace br.com.maplink.calculorota.facade
{
    public class CalcularRotaFacade
    {
        private CalculoRotaBusiness _bus;

        public CalcularRotaFacade()
        {
            _bus = new CalculoRotaBusiness();
        }

        public ResultadoCalculoV1 CalcularRotaMaisRapidaPorListaEnderecos(IList<DadosEntradaV1> entrada)
        {
            return _bus.CalcularRota(entrada, TiposCalculoRota.MaisRapida);
        }

        public ResultadoCalculoV1 CalcularRotaEvitandoTransitoPorListaEnderecos(IList<DadosEntradaV1> entrada)
        {
            return _bus.CalcularRota(entrada, TiposCalculoRota.EvitandoTransito);
        }
    }
}
