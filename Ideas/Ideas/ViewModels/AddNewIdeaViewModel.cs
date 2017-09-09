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
    public class AddNewIdeaViewModel
    {
        private ApiServices _apiservices = new ApiServices();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var idea = new Idea
                    {
                        Title = Title,
                        Description = Description,
                        Category = Category
                    };
                    await _apiservices.PostIdeasAsync(idea,Settings.AccessToken);
                });
            }
        }
    }
}
