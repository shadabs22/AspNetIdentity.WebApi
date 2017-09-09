using Ideas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ideas.Views
{
    public partial class IdeaListPage : ContentPage
    {
        public IdeaListPage()
        {
            InitializeComponent();
        }

        private async void GoToNewIdeaPage_Clicked(Object sender,EventArgs e)
        {
            try
            {         
            await Navigation.PushAsync(new AddNewIdeaPage());
            }
            catch (Exception ex)
            {
            }
        }

        private async void IdeasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var idea = e.Item as Idea;
            await Navigation.PushAsync(new EditIdeaPage(idea));
        }
    }
}
