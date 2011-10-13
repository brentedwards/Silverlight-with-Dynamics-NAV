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
using NAV.Models.Repositories.WCF.WcfServices;

namespace NAV.Models.Repositories.WCF
{
	public sealed class WcfRepository
	{
		private const string BASE_URL = "http://silverlight.digitalmajik.com:8123/DynamicsWCF/Services";

		public static WCFServicesClient GetService()
		{
			BasicHttpBinding navWSBinding = new BasicHttpBinding();
			navWSBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
			navWSBinding.MaxReceivedMessageSize = 2147483647;
			navWSBinding.ReceiveTimeout = new TimeSpan(0, 0, 20, 0, 0);

			var endpoint = new EndpointAddress(BASE_URL);
			var webService = new WCFServicesClient(navWSBinding, endpoint);
			return webService;
		}
	}
}
