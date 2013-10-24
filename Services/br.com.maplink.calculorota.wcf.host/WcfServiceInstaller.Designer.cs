namespace WcfServiceHost
{
	partial class WcfServiceInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();

			//
			// create installer and process installer
			//
			this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
			this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();

			// 
			// serviceInstaller1
			// 
			this.serviceInstaller1.Description = this.serviceDescription;
			this.serviceInstaller1.DisplayName = this.serviceDisplayName;
			this.serviceInstaller1.ServiceName = this.serviceName;
			// 
			// serviceProcessInstaller1
			// 
			this.serviceProcessInstaller1.Password = null;
			this.serviceProcessInstaller1.Username = null;
			// 
			// ServiceHostInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] { this.serviceInstaller1, this.serviceProcessInstaller1 });

		}

		private string serviceName = "WcfService";
		private string serviceDescription = "WCF Service Host";
		private string serviceDisplayName = "Service used to host simply configured net.tcp WCF services.";

		private System.ServiceProcess.ServiceInstaller serviceInstaller1;
		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;

		#endregion
	}
}