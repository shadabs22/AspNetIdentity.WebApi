using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ideas.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void GoToIdeasCommand(Object sender,EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new NavigationPage(new IdeaListPage()));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
