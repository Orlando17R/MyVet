using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using MyVet;
using MyVet.Common.Models;
using MyVet.Common.Services;

namespace MyVet.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnable;
        private DelegateCommand _loginCommand;


        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService): base(navigationService)
        {
            Title = "MyVet - LOGIN";
            IsRunning = false;
            IsEnable = true;
            _apiService = apiService;
        }

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public string Email { get; set; }

        public string Password 
        { 
            get => _password; 
            set => SetProperty(ref _password, value); 
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe digitar un email.", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe digitar una contrasena.", "Aceptar");
                return;
            }

            IsRunning = true;
            IsEnable = false;

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url,"Account","/CreateToken",request);

            IsRunning = false;
            IsEnable = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email o password no validos", "Aceptar");
                Password = string.Empty;
                return;
            }

            await App.Current.MainPage.DisplayAlert("Ok", "Cargando...!", "Aceptar");
        }



}//final class
}//final namespace
