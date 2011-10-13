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

namespace NAV.Core.ViewModels.Design
{
	public sealed class DesignCustomersViewModel : CustomersViewModel
	{
		public DesignCustomersViewModel()
			: base(null, null)
		{
		}

		public override bool IsLoading
		{
			get { return false; }
		}
	}
}
