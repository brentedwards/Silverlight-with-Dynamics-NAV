using System.ComponentModel;
using NAV.Core.IOC;

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
					return new LoginViewModel(null);
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

		private bool IsInDesignMode
		{
			get { return DesignerProperties.IsInDesignTool; }
		}
	}
}