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
using System.ComponentModel;

namespace NAV.Models.Repositories.Mock
{
	public sealed class MockLoginRepository : ILoginRepository, IRepository
	{
		public void LoginAsync(LoginCredentials credentials, Action<bool, string, Exception> callback)
		{
			var worker = new BackgroundWorker();
			worker.DoWork += (sender, e) =>
			{
				System.Threading.Thread.Sleep(2000);
			};
			worker.RunWorkerCompleted += (sender, e) =>
			{
				callback(true, "blah", null);
			};
			worker.RunWorkerAsync();
		}
	}
}
