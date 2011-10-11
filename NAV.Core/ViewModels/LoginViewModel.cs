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
using NAV.Models.Repositories;
using Bxf.Xaml;
using Bxf;

namespace NAV.Core.ViewModels
{
	public sealed class LoginViewModel : ViewModelBase
	{
		private ILoginRepository LoginRepository { get; set; }

		public LoginViewModel(ILoginRepository loginRepository)
		{
			LoginRepository = loginRepository;
		}

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
				(result, ex) =>
				{
					IsLoading = false;
					if (ex == null)
					{
						DidLoginFail = result;
						if (!DidLoginFail)
						{
							// Show the next view.
						}
					}
					else
					{
						Shell.Instance.ShowError("There was an error logging in.", "Error");
					}
				});
		}
	}
}
