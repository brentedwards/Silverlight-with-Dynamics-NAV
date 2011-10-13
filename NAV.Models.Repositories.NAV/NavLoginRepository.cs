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

namespace NAV.Models.Repositories.NAV
{
	public sealed class NavLoginRepository : ILoginRepository, IRepository
	{
		public void LoginAsync(LoginCredentials credentials, Action<bool, string, Exception> callback)
		{
			try
			{
				var service = NavRepository.GetService();

				var domain = "SYMDEV";
				var username = credentials.Username;
				var parts = credentials.Username.Split('\\');
				if (parts.Length == 2)
				{
					domain = parts[0];
					username = parts[1];
				}

				service.ValidateLoginCredentialsCompleted += (sender, args) =>
					{
						if (args.Error == null)
						{
							callback(args.Result, args.authToken, null);
						}
						else
						{
							callback(false, null, args.Error);
						}
					};
				service.ValidateLoginCredentialsAsync(domain, username, credentials.Password, string.Empty);
			}
			catch (Exception ex)
			{
				callback(false, null, ex);
			}
		}
	}
}
