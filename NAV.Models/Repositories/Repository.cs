using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;
using NAV.Models.DynamicsNAVSilverlight;

namespace NAV.Models.Repositories
{
	public abstract class Repository
	{
		protected static SilverlightWeb_PortClient GetService()
		{
			BasicHttpBinding navWSBinding = new BasicHttpBinding();
			navWSBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
			navWSBinding.MaxReceivedMessageSize = 2147483647;
			navWSBinding.ReceiveTimeout = new TimeSpan(0, 0, 20, 0, 0);

			var endpoint = new EndpointAddress(Constants.BASE_URL);
			var webService = new SilverlightWeb_PortClient(navWSBinding, endpoint);
			return webService;
		}
	}
}
