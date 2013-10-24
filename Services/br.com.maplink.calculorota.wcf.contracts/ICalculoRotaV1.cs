using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using br.com.maplink.calculorota.business.dtos;
using br.com.maplink.calculorota.common.wcf;

namespace br.com.maplink.calculorota.wcf.contracts
{
    [ServiceContract(Namespace = "http://maplink.com.br/CalculoRota/V1", Name = "CalculoRota")]
    public interface ICalculoRotaV1
    {
        [OperationContract]
        [FaultContract(typeof(common.wcf.WcfCalculoRotaFault))]
        ResultadoCalculoV1 CalcularRotaMaisRapida(List<DadosEntradaV1> entrada);

        [OperationContract]
        [FaultContract(typeof(common.wcf.WcfCalculoRotaFault))]
        ResultadoCalculoV1 CalcularRotaEvitandoTransito(List<DadosEntradaV1> entrada);
    }
}
