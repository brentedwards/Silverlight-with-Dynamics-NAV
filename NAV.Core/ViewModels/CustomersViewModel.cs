using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using NAV.Models.Repositories;
using NAV.Models;
using System.Collections.Generic;

namespace NAV.Core.ViewModels
{
	public sealed class CustomersViewModel : ViewModelBase
	{
		public CustomersViewModel(ICustomerRepository customerRepository)
		{
			CustomerRepository = customerRepository;

			CustomerRepository.LoadCustomersAsync((customers, ex) =>
				{
					if (ex == null)
					{
						Customers = Customers;
					}
					else
					{
						Bxf.Shell.Instance.ShowError("Error loading Customers.", "Error");
					}
				});
		}

		private ICustomerRepository CustomerRepository { get; set; }

		private IEnumerable<Customer> _customers;
		public IEnumerable<Customer> Customers
		{
			get { return _customers; }
			set
			{
				_customers = value;
				NotifyPropertyChanged("Customers");

				SelectedCustomer = _customers.FirstOrDefault();
			}
		}

		private Customer _selectedCustomer;
		public Customer SelectedCustomer
		{
			get { return _selectedCustomer; }
			set
			{
				_selectedCustomer = value;
				NotifyPropertyChanged("SelectedCustomer");
			}
		}
	}
}
