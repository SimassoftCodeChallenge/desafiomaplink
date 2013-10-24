using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using br.com.maplink.calculorota.business.dtos;

namespace br.com.maplink.calculorota.wcf.contracts
{
    [ServiceContract(Namespace = "http://maplink.com.br/CalculoRotaRestFul/V1", Name = "CalculoRota")]
    public interface ICalculoRotaRestFul
    {
        [OperationContract]
        [WebGet(UriTemplate = "RotaMaisCurta/?dadosOrigem={dadosOrigem}&dadosDestino={dadosDestino}", ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(common.wcf.WcfCalculoRotaFault))]
        ResultadoCalculoV1 CalcularRotaMaisRapida(string dadosOrigem, string dadosDestino);

        [OperationContract]
        [WebGet(UriTemplate = "RotaMaisRapida/?dadosOrigem={dadosOrigem}&dadosDestino={dadosDestino}", ResponseFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(common.wcf.WcfCalculoRotaFault))]
        ResultadoCalculoV1 CalcularRotaEvitandoTransito(string dadosOrigem, string dadosDestino);
    }
}
