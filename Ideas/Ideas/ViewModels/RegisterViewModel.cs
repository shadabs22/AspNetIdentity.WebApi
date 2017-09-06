using Ideas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Ideas.Helpers;
namespace Ideas.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices _ApiServices = new ApiServices();
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() => {
                   var isSuccess= await _ApiServices.RegisterAsync(Email, Password, ConfirmPassword);
                    if(isSuccess)
                    {
                        Settings.Username = Email;
                        Settings.Password = Password;
                        Message = "Registered successfully";
                    }
                    else
                    {
                        Message = "Retry later";
                    }
                });
            }
        }
    }
}
