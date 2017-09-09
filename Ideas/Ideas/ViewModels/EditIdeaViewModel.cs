using Ideas.Helpers;
using Ideas.Models;
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
    public class EditIdeaViewModel
    {
        private ApiServices _apiservices = new ApiServices();
        public Idea idea { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async () =>
                {           
                    await _apiservices.PutIdeasAsync(idea, Settings.AccessToken);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiservices.DeleteIdeasAsync(idea.Id, Settings.AccessToken);
                });
            }
        }
    }
}
