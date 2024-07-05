using Deportivo.Common.Models;
using Deportivo.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Deportivo.Prism.ViewModels
{
    public class AdicionalesPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<AdicionalesResponse> _adicionales;
        public AdicionalesPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title = "Adicionales";
            _apiService = apiService;
            LoadAdicionalesAsync();
        }

        public List<AdicionalesResponse> Adicionales
        {
            get => _adicionales;
            set => SetProperty(ref _adicionales, value);
        }
        private async void LoadAdicionalesAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<AccesoriosResponse>(url, "/api", "/AAdicionales");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            Adicionales = (List<AdicionalesResponse>)response.Result;
        }
    }
}
