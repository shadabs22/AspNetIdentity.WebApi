using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ideas.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        protected async void GoToLoginPage(Object eender,EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
