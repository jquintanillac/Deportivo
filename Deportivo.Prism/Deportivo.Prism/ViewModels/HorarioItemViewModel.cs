using Deportivo.Common.Models;
using Deportivo.Prism.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deportivo.Prism.ViewModels
{
    public class HorarioItemViewModel : HorarioResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectClienteCommand;
        public HorarioItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectClienteCommand => _selectClienteCommand ?? (_selectClienteCommand = new DelegateCommand(SelectClienteAsync));

        private async void SelectClienteAsync()
        {
            var parameters = new NavigationParameters
            {
                { "Horarios", this }
            };
            parameters.Add("Horarios", this);
            await _navigationService.NavigateAsync(nameof(ClientePage), parameters);
        }
    }
}
