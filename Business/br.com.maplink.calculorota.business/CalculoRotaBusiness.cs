using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.maplink.calculorota.business.Exceptions;
using br.com.maplink.calculorota.business.dtos;
using br.com.maplink.calculorota.business.entities;
using br.com.maplink.calculorota.common.util;
using br.com.maplink.calculorota.data;

namespace br.com.maplink.calculorota.business
{
    public class CalculoRotaBusiness
    {
        private CalculoRotaData _data;

        public CalculoRotaBusiness()
        {
            _data = new CalculoRotaData();
        }


        public ResultadoCalculoV1 CalcularRota(IList<DadosEntradaV1> entrada, TiposCalculoRota tc)
        {
            if (entrada.Count < 2)
            {
                throw new CalculoRotaBusinessException("entrada deve conter ao menos 2 registros!");
            }

            var map = new MapperHelper<DadosEntradaV1, EnderecoEntity>();
            var map2 = new MapperHelper<ResultadoCalculoRotaEntity, ResultadoCalculoV1>();
            
            var enderecos = map.ConvertToList(entrada);

            var coordenadas = _data.ObterCoordenadas(enderecos);
            var r = _data.CalcularRota(coordenadas, tc);
            
            return map2.Convert(r);
        }
    }
}
