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
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.ComponentModel;

namespace NAV.Models.Repositories.NAV
{
	public class NavCustomerRepository : CustomerRepository, ICustomerRepository, IRepository
	{
		public virtual void LoadCustomersAsync(string authToken, Action<IEnumerable<Customer>, Exception> callback)
		{
			try
			{
				var service = NavRepository.GetService();
				service.GetCustomerListCompleted += (sender, args) =>
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
				service.GetCustomerListAsync(authToken, string.Empty, string.Empty);
			}
			catch (Exception ex)
			{
				callback(null, ex);
			}
		}

		public virtual void SaveCustomer(Customer customer, Action<bool, Exception> callback)
		{
			try
			{
				var doc = ToXml(customer);

				var service = NavRepository.GetService();
				service.SaveCustomerCompleted += (sender, args) =>
					{
						if (args.Error == null)
						{
							callback(true, null);
						}
						else
						{
							callback(false, args.Error);
						}
					};
				service.SaveCustomerAsync(string.Empty, doc.ToString());
			}
			catch (Exception ex)
			{
				callback(false, ex);
			}
		}
	}
}
