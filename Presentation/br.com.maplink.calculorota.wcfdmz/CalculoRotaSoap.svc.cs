using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using br.com.maplink.calculorota.business.dtos;
using br.com.maplink.calculorota.common.integration;
using br.com.maplink.calculorota.common.util;
using br.com.maplink.calculorota.wcf.contracts;

namespace br.com.maplink.calculorota.wcfdmz
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class CalculoRotaSoap : ICalculoRotaV1
    {
        private CalculoRotaWrapper _wrapper;
        public ResultadoCalculoV1 CalcularRotaMaisRapida(List<DadosEntradaV1> entrada)
        {
            var m = new MapperHelper<DadosEntradaV1, common.integration.CalculoRota.DadosEntrada>();
            var m2 = new MapperHelper<common.integration.CalculoRota.ResultadoCalculo, ResultadoCalculoV1>();

            _wrapper = new CalculoRotaWrapper();
            var r = _wrapper.CalcularRotaMaisRapida(m.ConvertToList(entrada).ToList());

            return m2.Convert(r);
        }

        public ResultadoCalculoV1 CalcularRotaEvitandoTransito(List<DadosEntradaV1> entrada)
        {
            var m = new MapperHelper<DadosEntradaV1, common.integration.CalculoRota.DadosEntrada>();
            var m2 = new MapperHelper<common.integration.CalculoRota.ResultadoCalculo, ResultadoCalculoV1>();

            _wrapper = new CalculoRotaWrapper();
            var r = _wrapper.CalcularRotaEvitandoTransito(m.ConvertToList(entrada).ToList());

            return m2.Convert(r);
        }
    }
}
