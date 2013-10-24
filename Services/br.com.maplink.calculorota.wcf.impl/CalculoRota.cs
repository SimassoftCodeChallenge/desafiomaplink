using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.maplink.calculorota.business.dtos;
using br.com.maplink.calculorota.facade;
using br.com.maplink.calculorota.common.wcf;
using br.com.maplink.calculorota.wcf.contracts;

namespace br.com.maplink.calculorota.wcf.impl
{
    public class CalculoRota : ICalculoRotaV1
    {
        private CalcularRotaFacade _fac;

        public CalculoRota()
        {
            _fac = new CalcularRotaFacade();
        }

        public ResultadoCalculoV1 CalcularRotaMaisRapida(List<DadosEntradaV1> entrada)
        {
            try
            {
                return _fac.CalcularRotaMaisRapidaPorListaEnderecos(entrada);
            }
            catch (Exception e)
            {
                throw WcfCalculoRotaFaultFactory.CreateWcfServiceFault(e);
            }
        }

        public ResultadoCalculoV1 CalcularRotaEvitandoTransito(List<DadosEntradaV1> entrada)
        {
            try
            {
                return _fac.CalcularRotaEvitandoTransitoPorListaEnderecos(entrada);
            }
            catch (Exception e)
            {
                throw WcfCalculoRotaFaultFactory.CreateWcfServiceFault(e);
            }
        }
    }
}
