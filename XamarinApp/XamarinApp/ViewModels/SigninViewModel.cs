﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp.Helpers;
using XamarinApp.Models;
using XamarinApp.Platform;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    /// <summary>
    /// The ViewModel responsible for Signin and Signup.
    /// </summary>
    public class SigninViewModel : INotifyPropertyChanged
    {
        private string _message;
        private bool _isBusy;
        private readonly AuthenticatorService _authenticatorService;
        private readonly NavigationService _navigationService;

        public CreateUserBindingModel Model { get; set; }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand SignupCommand => new Command(async () => await SignupAsync());

        public ICommand SigninCommand => new Command(async () => await SigninAsync());

        public SigninViewModel()
        {
            _navigationService = new NavigationService();
            _authenticatorService = new AuthenticatorService();
            
            Model = new CreateUserBindingModel
            {
                Username = "TestUser1",
                Password = "@Aa123456",
                ConfirmPassword = "@Aa123456",
                Email = "h1@d.c",
                FirstName = "Test1",
                LastName = "User1",
                //RoleName = ""
            };

            if (!string.IsNullOrEmpty(Settings.Username))
            {
                Model.Username = Settings.Username;
            }
            if (!string.IsNullOrEmpty(Settings.Email))
            {
                Model.Email = Settings.Email;
            }
            if (!string.IsNullOrEmpty(Settings.Password))
            {
                Model.Password = Settings.Password;
            }
        }

        /// <summary>
        /// Register the user to the API.
        /// </summary>
        /// <returns></returns>
        private async Task SignupAsync()
        {
            if (IsBusy)
                return;

            // TODO: validate username and password

            IsBusy = true;
            Message = "Signing up...";
            AuthResponse response = null;

            // TODO: check internet connectivity
            try
            {
                response = await _authenticatorService.SignupAsync(Model);

                Message = response.Result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }

            if (response != null && response.IsSuccess)
            {
                // save username and password
                Settings.Username = Model.Username;
                Settings.Email = Model.Email;
                Settings.Password = Model.Password;

                await _navigationService.NavigateToSigninPage();
            }
        }

        private async Task SigninAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Message = "Signing in...";

            // TODO: validate username and password

            try
            {
                var response = await _authenticatorService.SigninAsync(Model.Username, Model.Password);

                // response.Result contains the access_token
                Message = response.Result;

                // TODO: save access_token in settings
                Settings.AccessToken = response.Result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
