using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using br.com.maplink.calculorota.business.entities;
using br.com.maplink.calculorota.common.integration;
using br.com.maplink.calculorota.common.integration.Route;

namespace br.com.maplink.calculorota.data
{
    public class CalculoRotaData
    {
        private readonly AddressFinderWrapper _address;
        private readonly RouteWrapper _route;

        public CalculoRotaData()
        {
            _address = new AddressFinderWrapper();
            _route = new RouteWrapper();

        }

        public IList<Coordenadas> ObterCoordenadas(IList<EnderecoEntity> enderecos)
        {
            IList<Coordenadas> c = enderecos.Select(e => _address.GetXY(e.Rua,
                                                        e.Numero,
                                                        e.Cidade,
                                                        e.Estado,
                                                        e.Bairro,
                                                        e.Cep)).Select(r => new Coordenadas { X = r.x, Y = r.y }).ToList();

            return c;

        }

        public ResultadoCalculoRotaEntity CalcularRota(IList<Coordenadas> p, TiposCalculoRota tp)
        {
            var r = new ResultadoCalculoRotaEntity();

            RouteInfo ri = _route.GetRoute(new Point { x = p[0].X, y = p[0].Y }, new Point { x = p[1].X, y = p[1].Y }, (RouteWrapper.TipoRota)tp);

            r.CustoTotalCombustivel = (decimal)ri.routeTotals.totalfuelCost;
            r.CustoTotalPedagio = (decimal)ri.routeTotals.totaltollFeeCost;
            r.DistanciaTotalRota = (long)ri.routeTotals.totalDistance;

            //"PT11H40M"
            //"PT11H7M"
            r.TempoTotalRota = TimeSpan.ParseExact(ri.routeTotals.totalTime, @"\P\T%h\H%m\M", CultureInfo.InvariantCulture);

            return r;
        }
    }

    public enum TiposCalculoRota
    {
        MaisRapida = 0,
        EvitandoTransito = 23
    }

    public struct Coordenadas
    {
        public double X;
        public double Y;
    }
}
