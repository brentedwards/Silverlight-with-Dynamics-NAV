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
using Castle.Windsor;

namespace NAV.Core.IOC
{
	public sealed class Ioc
	{
		private static IWindsorContainer _container;
		private static object _lock = new object();

		public static IWindsorContainer Container
		{
			get
			{
				if (_container == null)
				{
					lock (_lock)
					{
						if (_container == null)
						{
							_container = new WindsorContainer();
						}
					}
				}

				return _container;
			}
			set
			{
				lock (_lock)
				{
					_container = value;
				}
			}
		}
	}
}
