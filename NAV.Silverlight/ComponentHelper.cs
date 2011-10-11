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
using Castle.MicroKernel.Registration;

namespace NAV.Silverlight
{
	public sealed class ComponentHelper
	{
		public static void RegisterComponents(IWindsorContainer container)
		{
			container
				.Register(AllTypes
							.FromAssembly(typeof(NAV.Models.Repositories.RepositoryMarker).Assembly)
							.BasedOn<NAV.Models.Repositories.IRepository>()
							.WithService.FirstInterface())

				.Register(AllTypes
							.FromAssembly(typeof(NAV.Core.ViewModels.ViewModelBase).Assembly)
							.BasedOn<NAV.Core.ViewModels.ViewModelBase>()
							.Configure(component => component
														.Named(component.ServiceType.FullName.ToLowerInvariant())
														.LifeStyle.Transient));
		}
	}
}
