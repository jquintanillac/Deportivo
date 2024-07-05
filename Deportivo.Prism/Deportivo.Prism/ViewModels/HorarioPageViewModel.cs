using Deportivo.Common.Models;
using Deportivo.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Deportivo.Prism.ViewModels
{
    public class HorarioPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private List<HorarioItemViewModel> _horarios;
        public HorarioPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title = "Horarios";
            _navigationService = navigationService;
            _apiService = apiService;
            LoadAccesoriosAsync();
        }

        public List<HorarioItemViewModel> Horarios
        {
            get => _horarios;
            set => SetProperty(ref _horarios, value);
        }
        private async void LoadAccesoriosAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<HorarioResponse>(url, "/api", "/AHorarios");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var horarios = (List<HorarioResponse>)response.Result;
            Horarios = horarios.Select(t => new HorarioItemViewModel(_navigationService)
            {
                id_hordep = t.id_hordep,
                id_espdep = t.id_espdep,
                id_client = t.id_client,
                client_desc = t.client_desc,
                espdep_desc = t.espdep_desc,
                hordep_desc = t.hordep_desc,
                hordep_fecing = t.hordep_fecing,
                hordep_fecsal = t.hordep_fecsal,
                hordep_obse = t.hordep_obse,
                hordep_tipo = t.hordep_tipo
            }).ToList();

        }
    }
}
