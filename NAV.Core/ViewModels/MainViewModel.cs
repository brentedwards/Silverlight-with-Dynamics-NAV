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
using Bxf;
using NAV.Core.Shell;

namespace NAV.Core.ViewModels
{
	public sealed class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			var shell = new NavigationShell();
			Bxf.Shell.Instance = shell;

			var presenter = shell as IPresenter;
			presenter.OnShowView += (view, region) =>
				{
					NextView = view.ViewName;
				};

			Bxf.Shell.Instance.ShowView("/Views/Login.xaml", null, null, null);
		}

		private string _nextView;
		public string NextView
		{
			get { return _nextView; }
			private set
			{
				_nextView = value;
				NotifyPropertyChanged("NextView");
			}
		}
	}
}
