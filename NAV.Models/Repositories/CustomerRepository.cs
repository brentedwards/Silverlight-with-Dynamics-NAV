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

namespace NAV.Models.Repositories
{
	public sealed class CustomerRepository : Repository, ICustomerRepository, IRepository
	{
		public void LoadCustomersAsync(Action<IEnumerable<Customer>, Exception> callback)
		{
			try
			{
				var service = GetService();
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
			}
			catch (Exception ex)
			{
				callback(null, ex);
			}
		}

		private IEnumerable<Customer> ParseXml(XDocument doc)
		{
			var result = new List<Customer>();

			XNamespace ns = Constants.NAMESPACE_CUSTOMER;

			var customers = doc.Root.Element(ns + "Customers").Elements(ns + "Customer");
			foreach (var customer in customers)
			{
				var customerRecord = new Customer();

				var fields = customer.Elements();
				foreach (var field in fields)
				{
					var fieldId = field.Name.ToString();
					var caption = field.Attribute(ns + "FieldCaption").Value;
					var value = field.Value;

					customerRecord.AddField(fieldId, caption, value);
				}

				result.Add(customerRecord);
			}

			return result;
		}
	}
}
