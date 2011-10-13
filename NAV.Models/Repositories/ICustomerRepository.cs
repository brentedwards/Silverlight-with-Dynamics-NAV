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

namespace NAV.Models.Repositories
{
	public interface ICustomerRepository
	{
		void LoadCustomersAsync(string authToken, Action<IEnumerable<Customer>, Exception> callback);
		void SaveCustomer(Customer customer, Action<bool, Exception> callback);
	}
}
