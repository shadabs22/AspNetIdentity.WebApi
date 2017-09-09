using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ideas.Views
{
    public partial class AddNewIdeaPage : ContentPage
    {
        public AddNewIdeaPage()
        {
            InitializeComponent();
        }



        private async void GoToIdeaPage_Clicked(Object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new IdeaListPage());
            }
            catch (Exception ex)
            {
            }
        }
    }
}
