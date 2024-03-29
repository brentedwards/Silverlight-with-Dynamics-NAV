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
using NAV.Models.Repositories;
using Bxf.Xaml;
using Bxf;
using NAV.Models;

namespace NAV.Core.ViewModels
{
	public sealed class LoginViewModel : ViewModelBase
	{
		public LoginViewModel(ILoginRepository loginRepository, UserMetaData userMetaData)
		{
			LoginRepository = loginRepository;
			UserMetaData = userMetaData;
		}

		private ILoginRepository LoginRepository { get; set; }
		private UserMetaData UserMetaData { get; set; }

		private string _userName;
		public string UserName
		{
			get { return _userName; }
			set
			{
				_userName = value;
				NotifyPropertyChanged("UserName");
			}
		}

		private bool _didLoginFail;
		public bool DidLoginFail
		{
			get { return _didLoginFail; }
			set
			{
				_didLoginFail = value;
				NotifyPropertyChanged("DidLoginFail");
			}
		}

		public void Login(object sender, ExecuteEventArgs args)
		{
			IsLoading = true;
			DidLoginFail = false;

			LoginRepository.LoginAsync(
				new Models.LoginCredentials(UserName, args.MethodParameter as string),
				(result, authToken, ex) =>
				{
					IsLoading = false;
					if (ex == null)
					{
						DidLoginFail = !result;
						if (!DidLoginFail)
						{
							UserMetaData.AuthToken = authToken;
							Bxf.Shell.Instance.ShowView("/Views/Customers.xaml", null, null, null);
						}
					}
					else
					{
						DidLoginFail = true;
					}
				});
		}
	}
}
