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

namespace NAV.Core.Shell
{
	// This class was written by Rockford Lhotka in support of Bxf:
	// http://bxf.codeplex.com/SourceControl/changeset/view/87588#1541280
	public class NavigationShell : Bxf.Shell
	{
		public NavigationShell()
		{
			// use the custom view factory
			this.ViewFactory = new CustomViewFactory();
		}

		protected override void InitializeBindingResource(Bxf.IView view)
		{
			// do nothing since the view is "lazy loaded" by
			// the navigation engine and the viewmodel is created
			// later
		}
	}

	public class CustomViewFactory : Bxf.ViewFactory
	{
		protected override UserControl CreateUserControl(string viewName)
		{
			// don't create a view - the navigation engine does that
			return null;
		}
	}
}
