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
using System.IO;
using System.Xml.Linq;

namespace NAV.Models.Repositories.WCF
{
	public sealed class WcfCustomerRepository : CustomerRepository, ICustomerRepository, IRepository
	{
		public void LoadCustomersAsync(string authToken, Action<System.Collections.Generic.IEnumerable<Customer>, Exception> callback)
		{
			try
			{
				var service = WcfRepository.GetService();
				service.ProxyGetCustomerListCompleted += (sender, args) =>
				{
					if (args.Error == null)
					{
						var stream = new StringReader(args.xmlData);
						var doc = XDocument.Load(stream);

						try
						{
							var customers = ParseXml(doc);
							callback(customers, null);
						}
						catch (Exception ex)
						{
							callback(null, ex);
						}
					}
				};
				service.ProxyGetCustomerListAsync(authToken, string.Empty, string.Empty);
			}
			catch (Exception ex)
			{
				callback(null, ex);
			}
		}

		public void SaveCustomer(Customer customer, Action<bool, Exception> callback)
		{
			throw new NotImplementedException();
		}
	}
}
