using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideas.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Ideas.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ideas.Helpers;

namespace Ideas.ViewModels
{
    public class IdeasViewModel: INotifyPropertyChanged
    {
        ApiServices _AppServices = new ApiServices();

        //public string AccessToken { get; set; }

        List<Idea> _Ideas = null;

        public List<Idea> Ideas {
            get {  return _Ideas; }
            set { _Ideas = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetIdeasCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var AccessToken = Settings.AccessToken;
                    Ideas = await _AppServices.GetIdeasAsync(AccessToken);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
