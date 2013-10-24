using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace WcfServiceHost
{
	[RunInstaller(true)]
	public partial class WcfServiceInstaller : Installer
	{
		public WcfServiceInstaller()
		{
			InitializeComponent();
		}
	}
}
