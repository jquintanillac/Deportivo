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
    public class AccesoriosPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<AccesoriosResponse> _accesorios;
        public AccesoriosPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title = "Accesorios";
            _apiService = apiService;
            LoadAccesoriosAsync();
        }       

        public List<AccesoriosResponse> Accesorios 
        { 
            get => _accesorios; 
            set => SetProperty(ref _accesorios, value); 
        }
        private async void LoadAccesoriosAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<AccesoriosResponse>(url, "/api", "/AAccesorios");
            if (!response.IsSuccess) 
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return; 
            }

            Accesorios = (List<AccesoriosResponse>)response.Result;   
        }
    }
}
