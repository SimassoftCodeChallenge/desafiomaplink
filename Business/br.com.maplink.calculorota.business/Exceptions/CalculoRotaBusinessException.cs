using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.maplink.calculorota.business.Exceptions
{
    [Serializable]
    public class CalculoRotaBusinessException : ApplicationException
    {
        public CalculoRotaBusinessException(string msg)
            : base(msg)
        {
        }
    }
}
