﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace NAV.Models.Repositories.WCF
{
	public sealed class WcfLoginRepository : ILoginRepository, IRepository
	{
		public void LoginAsync(LoginCredentials credentials, Action<bool, string, Exception> callback)
		{
			try
			{
				var service = WcfRepository.GetService();

				var domain = "SYMDEV";
				var username = credentials.Username;
				var parts = credentials.Username.Split('\\');
				if (parts.Length == 2)
				{
					domain = parts[0];
					username = parts[1];
				}

				service.ProxyValidateLoginCredentialsCompleted += (sender, args) =>
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
				service.ProxyValidateLoginCredentialsAsync(domain, username, credentials.Password, string.Empty);
			}
			catch (Exception ex)
			{
				callback(false, null, ex);
			}
		}
	}
}
