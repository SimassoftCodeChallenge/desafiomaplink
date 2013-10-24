using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
#if(DEBUG)
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, MaxItemsInObjectGraph = 131072, IncludeExceptionDetailInFaults = true)]
#else
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, MaxItemsInObjectGraph = 131072, IncludeExceptionDetailInFaults = false)]
#endif
    public abstract class WcfServiceBase
    {
        public void Authorize()
        {
            string[] groups = null;
            Type serviceType = this.GetType();
            var configItem = Config.GetServiceConfig(serviceType);

            if (null != configItem)
            {
                groups = configItem.Item.AuthorizedGroups.Split(',');
            }

            if (null != groups)
            {
                PrincipalPermission[] pps = new PrincipalPermission[groups.Length];
                for (int i = 0; i < groups.Length; i++)
                {
                    pps[i] = new PrincipalPermission(null, groups[i]);
                }

                PrincipalPermission pp = pps[0];
                if (groups.Length > 0)
                {
                    for (int i = 1; i < groups.Length; i++)
                    {
                        pp = (PrincipalPermission)pp.Union(pps[i]);
                    }
                }
                pp.Demand();
            }
            else
                throw new SecurityException("Group is null");
        }
    }
}
