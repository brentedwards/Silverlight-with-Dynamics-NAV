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

namespace NAV.Models.Repositories
{
	public sealed class LoginRepository : Repository, ILoginRepository, IRepository
	{
		public void LoginAsync(LoginCredentials credentials, Action<bool, Exception> callback)
		{
			callback(true, null); // TODO: Put this back when the services work.
			//try
			//{
			//    var service = GetService();

			//    var domain = "SYMDEV";
			//    var username = credentials.Username;
			//    var parts = credentials.Username.Split('\\');
			//    if (parts.Length == 2)
			//    {
			//        domain = parts[0];
			//        username = parts[1];
			//    }

			//    service.ValidateLoginCredentialsCompleted += (sender, args) =>
			//        {
			//            if (args.Error == null)
			//            {
			//                callback(args.Result.Equals("True", StringComparison.OrdinalIgnoreCase), null);
			//            }
			//            else
			//            {
			//                callback(false, args.Error);
			//            }
			//        };
			//    service.ValidateLoginCredentialsAsync(domain, username, credentials.Password, string.Empty);
			//}
			//catch (Exception ex)
			//{
			//    callback(false, ex);
			//}
		}
	}
}
