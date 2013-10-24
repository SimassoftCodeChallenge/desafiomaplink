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
using br.com.maplink.calculorota.common.integration.CalculoRota;
using br.com.maplink.calculorota.common.util;
using br.com.maplink.calculorota.common.wcf;
using br.com.maplink.calculorota.wcf.contracts;

namespace br.com.maplink.calculorota.wcfdmz
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class CalculoRotaRest : ICalculoRotaRestFul
    {
        private CalculoRotaWrapper _wrapper;
        public ResultadoCalculoV1 CalcularRotaMaisRapida(string dadosOrigem, string dadosDestino)
        {
            var l = new List<common.integration.CalculoRota.DadosEntrada>();
            var m2 = new MapperHelper<common.integration.CalculoRota.ResultadoCalculo, ResultadoCalculoV1>();

            if (dadosOrigem.Contains(",") == false || dadosDestino.Contains(",") == false)
            {
                throw WcfCalculoRotaFaultFactory.CreateWcfServiceFault(new ArgumentException("Você deve especificar corretamente os parametros: dadosOrigem=cep,estado,cidade,rua,numero&dadosDestino=cep,estado,cidade,rua,numero"));
            }

            string[] s = dadosOrigem.Split(',');
            string[] sd = dadosDestino.Split(',');

            l.Add(new DadosEntrada { Cep = s[0], Estado = s[1], Cidade = s[2], Rua = s[3], Numero = s[4] });
            l.Add(new DadosEntrada { Cep = sd[0], Estado = sd[1], Cidade = sd[2], Rua = sd[3], Numero = sd[4] });

            _wrapper = new CalculoRotaWrapper();
            var r = _wrapper.CalcularRotaMaisRapida(l);

            return m2.Convert(r);
        }

        public ResultadoCalculoV1 CalcularRotaEvitandoTransito(string dadosOrigem, string dadosDestino)
        {
            var l = new List<common.integration.CalculoRota.DadosEntrada>();
            var m2 = new MapperHelper<common.integration.CalculoRota.ResultadoCalculo, ResultadoCalculoV1>();

            if (dadosOrigem.Contains(",") == false || dadosDestino.Contains(",") == false)
            {
                throw WcfCalculoRotaFaultFactory.CreateWcfServiceFault(new ArgumentException("Você deve especificar corretamente os parametros: dadosOrigem=cep,estado,cidade,rua,numero&dadosDestino=cep,estado,cidade,rua,numero"));
            }

            string[] s = dadosOrigem.Split(',');
            string[] sd = dadosDestino.Split(',');

            l.Add(new DadosEntrada { Cep = s[0], Estado = s[1], Cidade = s[2], Rua = s[3], Numero = s[4] });
            l.Add(new DadosEntrada { Cep = sd[0], Estado = sd[1], Cidade = sd[2], Rua = sd[3], Numero = sd[4] });

            _wrapper = new CalculoRotaWrapper();
            var r = _wrapper.CalcularRotaEvitandoTransito(l);

            return m2.Convert(r);
        }

        public ResultadoCalculoV1 Teste(string d)
        {
            return new ResultadoCalculoV1
                {
                    CustoTotalCombustivel = 199,
                    CustoTotalPedagio = 199,
                    DistanciaTotalRota = 200,
                    TempoTotalRota = new TimeSpan(100, 9, 10, 1)
                };
        }
    }
}
