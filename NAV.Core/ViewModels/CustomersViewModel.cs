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
	public class CustomersViewModel : ViewModelBase
	{
		public CustomersViewModel(ICustomerRepository customerRepository, UserMetaData userMetaData)
		{
			CustomerRepository = customerRepository;
			UserMetaData = userMetaData;

			Status = "Loading Customers";
			IsLoading = true;
			CustomerRepository.LoadCustomersAsync(userMetaData.AuthToken, (customers, ex) =>
				{
					IsLoading = false;
					if (ex == null)
					{
						Customers = customers;
					}
					else
					{
						Bxf.Shell.Instance.ShowError("Error loading Customers.", "Error");
					}
				});
		}

		private ICustomerRepository CustomerRepository { get; set; }
		private UserMetaData UserMetaData { get; set; }

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

		private string _status;
		public string Status
		{
			get { return _status; }
			set
			{
				_status = value;
				NotifyPropertyChanged("Status");
			}
		}

		public void Save()
		{
			if (SelectedCustomer != null)
			{
				Status = "Saving Customer";
				IsLoading = true;
				CustomerRepository.SaveCustomer(SelectedCustomer, (result, ex) =>
					{
						IsLoading = false;
						if (result)
						{
							Bxf.Shell.Instance.ShowStatus(new Bxf.Status() { Text = "Customer Saved!" });
						}
						else
						{
							Bxf.Shell.Instance.ShowError("Error saving Customer", "Error");
						}
					});
			}
		}
	}
}
