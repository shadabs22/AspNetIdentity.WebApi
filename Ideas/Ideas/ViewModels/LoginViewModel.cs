using Ideas.Helpers;
using Ideas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ideas.ViewModels
{
    public class LoginViewModel
    {
        ApiServices _ApiServices = new ApiServices();
        public string Username { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () => {
                    try
                    {
                        var accesstoken = await _ApiServices.LoginAsync(Username, Password);
                        Settings.AccessToken = accesstoken;
                    }
                    catch (Exception e)
                    {

                    }
                });
            }
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
