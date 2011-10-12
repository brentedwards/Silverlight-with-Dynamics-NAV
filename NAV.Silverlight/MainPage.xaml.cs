using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Bxf;

namespace NAV.Silverlight
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();

			var presenter = Bxf.Shell.Instance as IPresenter;

			presenter.OnShowError += (message, title) =>
				{
					MessageBox.Show(message, title, MessageBoxButton.OK);
				};

			presenter.OnShowStatus += (status) =>
				{
					if (!string.IsNullOrEmpty(status.Text))
					{
						MessageBox.Show(status.Text);
					}
				};
		}
	}
}
