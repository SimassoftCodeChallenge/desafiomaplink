using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using br.com.maplink.calculorota.common.integration.AddresFinder;

namespace br.com.maplink.calculorota.common.integration
{
    public class AddressFinderWrapper : BaseIntegration
    {
        private readonly AddressFinder _finder;

        public AddressFinderWrapper()
            : base()
        {
            _finder = new AddressFinder();
            base.ConfigureProxy(_finder);
        }

        public Point GetXY(string rua, string numero, string cidade, string estado, string bairro, string cep)
        {
            return _finder.getXY(new Address
                {
                    street = rua,
                    houseNumber = numero,
                    city = new City { name = cidade, state = estado },
                    district = bairro,
                    zip = cep
                }, _token);
        }
    }
}
