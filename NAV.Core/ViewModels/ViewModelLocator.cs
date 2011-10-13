using System.ComponentModel;
using NAV.Core.IOC;
using NAV.Models;
using NAV.Core.ViewModels.Design;

namespace NAV.Core.ViewModels
{
	public class ViewModelLocator
	{
		public LoginViewModel Login
		{
			get
			{
				if (IsInDesignMode)
				{
					return new LoginViewModel(null, null);
				}
				else
				{
					return Ioc.Container.Resolve<LoginViewModel>();
				}
			}
		}

		public MainViewModel Main
		{
			get
			{
				if (IsInDesignMode)
				{
					return new MainViewModel();
				}
				else
				{
					return Ioc.Container.Resolve<MainViewModel>();
				}
			}
		}

		public CustomersViewModel Customers
		{
			get
			{
				if (IsInDesignMode)
				{
					return new DesignCustomersViewModel();
				}
				else
				{
					return Ioc.Container.Resolve<CustomersViewModel>();
				}
			}
		}

		public Customer CustomerDetail
		{
			get
			{
				if (IsInDesignMode)
				{
					return new Customer();
				}
				else
				{
					return null;
				}
			}
		}

		private bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}