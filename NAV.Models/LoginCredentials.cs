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

namespace NAV.Models
{
	public sealed class LoginCredentials
	{
		public string Username { get; private set; }
		public string Password { get; private set; }

		public LoginCredentials(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}
