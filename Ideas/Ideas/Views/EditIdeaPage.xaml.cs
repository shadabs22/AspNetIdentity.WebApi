using Ideas.Models;
using Ideas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Ideas.Views
{
    public partial class EditIdeaPage : ContentPage
    {
        public EditIdeaPage(Idea idea)
        {
            var editIdeaViewModel = new EditIdeaViewModel();
            editIdeaViewModel.idea = idea;
            BindingContext = editIdeaViewModel;
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
