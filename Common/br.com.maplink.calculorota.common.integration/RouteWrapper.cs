using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.maplink.calculorota.common.integration.Route;

namespace br.com.maplink.calculorota.common.integration
{
    public class RouteWrapper : BaseIntegration
    {
        private readonly Route.Route _route;

        public string Language { get; set; }

        public RouteWrapper()
            : base()
        {
            _route = new Route.Route();
            base.ConfigureProxy(_route);
            Language = "pt-br";
        }

        public RouteInfo GetRoute(Point origem, Point destino, TipoRota tp)
        {
            RouteStop[] a = new RouteStop[2] { new RouteStop {description = "origem", point = origem} , 
                                               new RouteStop {description = "destino", point = destino }};

            RouteOptions ro = new RouteOptions();
            ro.language = Language;

            //TODO: Criar enum com as possíveis opções: http://dev.maplink.com.br/webservices/rotas/#StructureVehicle
            ro.vehicle = new Vehicle();
            ro.vehicle.tollFeeCat = 2;
            ro.vehicle.averageConsumption = 10;
            ro.vehicle.averageSpeed = 60;
            ro.vehicle.tankCapacity = 50;
            ro.vehicle.fuelPrice = 2.60;

            //TODO: Criar as opções: http://dev.maplink.com.br/webservices/rotas/#StructureVehicle
            ro.routeDetails = new RouteDetails();
            ro.routeDetails.routeType = (int) tp;
            ro.routeDetails.descriptionType = 0;

            return _route.getRoute(a, ro, _token);
        }

        public static Point ConvertToRoutePoint(AddresFinder.Point p0)
        {
            return new Point { x = p0.x, y = p0.y };
        }

        public enum TipoRota
        {
            PadraoMaisRapida = 0,
            PadraoMaisCurta = 1,
            RotaAPe = 2,
            RotaEvitandoTransito = 23,
            RotaMaisRapidaConsiderandoTempoTransito = 24
        }

    }
}
