
using System.Runtime.Serialization;

namespace br.com.maplink.calculorota.business.dtos
{
    [DataContract(Namespace = "http://maplink.com.br/CalculoRota/V1/DadosEntrada", Name = "DadosEntrada")]
    public class DadosEntradaV1 : IDadosEntradaV1
    {
        [DataMember(IsRequired = true)]
        public string Rua { get; set; }

        [DataMember(IsRequired = true)]
        public string Numero { get; set; }

        [DataMember(IsRequired = true)]
        public string Cidade { get; set; }

        [DataMember(IsRequired = true)]
        public string Estado { get; set; }

        [DataMember(IsRequired = true)]
        public string Cep { get; set; }
    }

    public interface IDadosEntradaV1
    {
        string Rua { get; set; }
        string Numero { get; set; }
        string Cidade { get; set; }
        string Estado { get; set; }
        string Cep { get; set; }
    }
}
