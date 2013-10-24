using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using br.com.maplink.calculorota.wcf.host;

namespace br.com.maplink.calculorota.wcf.host
{
    partial class WcfService : ServiceBase
	{
		ServiceRunner serviceRunner = null;

		public WcfService()
		{
			InitializeComponent();
			serviceRunner = new ServiceRunner();
		}

		protected override void OnStart(string[] args)
		{
			serviceRunner.Start(args);
		}

		protected override void OnStop()
		{
			serviceRunner.Stop();
		}
	}
}
