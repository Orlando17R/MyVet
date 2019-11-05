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
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnable;
        private DelegateCommand _loginCommand;


        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService): base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService; 
            
            Title = "MyVet - LOGIN";
            IsRunning = false;
            IsEnable = true;


            //DELETE DESPUES
            Email = "orlan217@hotmail.com";
            Password = "123456789";
            
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
            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true; 
                await App.Current.MainPage.DisplayAlert("Error", "Email o password no validos", "Aceptar");
                Password = string.Empty;
                return;
            }


            var token = (TokenResponse)response.Result;
            var response2 = await _apiService.GetOwnerByEmailAsync(url, "api","/Owners/GetOwnerByEmail", "bearer", token.Token,Email);
            if (!response2.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert("Error", "Problemas con el usuario, favor contactar soporte", "Aceptar");
                Password = string.Empty;
                return;
            }

            var owner = (OwnerResponse)response2.Result;
            var parameters = new NavigationParameters
            {
                { "owner", owner }
            };


            IsRunning = false;
            IsEnable = true;

            //await App.Current.MainPage.DisplayAlert("Ok", "Cargando...!", "Aceptar");
            //Password = string.Empty;
            await _navigationService.NavigateAsync("PetsPage", parameters);
            Password = string.Empty;
        }



}//final class
}//final namespace
