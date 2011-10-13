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
using System.Xml.Linq;
using System.Collections.Generic;

namespace NAV.Models.Repositories
{
	public abstract class CustomerRepository
	{
		protected const string NAMESPACE_CUSTOMER = "http://silverlight.digitalmajik.com/GetCustomerList";

		protected IEnumerable<Customer> ParseXml(XDocument doc)
		{
			var result = new List<Customer>();

			XNamespace ns = NAMESPACE_CUSTOMER;

			var customers = doc.Root.Element(ns + "Customers").Elements(ns + "Customer");
			foreach (var customer in customers)
			{
				var customerRecord = new Customer();

				var fields = customer.Elements();
				foreach (var field in fields)
				{
					var fieldId = field.Name.LocalName;
					var caption = field.Attribute("FieldCaption").Value;
					var value = field.Value;

					customerRecord.AddField(fieldId, caption, value);
				}

				result.Add(customerRecord);
			}

			return result;
		}

		protected XDocument ToXml(Customer customer)
		{
			var doc = new XDocument();

			XNamespace ns = NAMESPACE_CUSTOMER;
			var root = new XElement(ns + "GetCustomerList");
			doc.Add(root);

			var customerNode = new XElement(ns + "Customer");
			root.Add(customerNode);

			foreach (var field in customer.Fields)
			{
				var fieldNode = new XElement(ns + field.FieldId, field.Value);
				fieldNode.SetAttributeValue(ns + "FieldCaption", field.Caption);

				customerNode.Add(fieldNode);
			}

			return doc;
		}
	}
}
