using Deportivo.Common.Services;
using Deportivo.Prism.ViewModels;
using Deportivo.Prism.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Deportivo.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HorarioPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AccesoriosPage, AccesoriosPageViewModel>();
            containerRegistry.RegisterForNavigation<AdicionalesPage, AdicionalesPageViewModel>();
            containerRegistry.RegisterForNavigation<ClientePage, ClientePageViewModel>();
            containerRegistry.RegisterForNavigation<DeportivoAccesorioPage, DeportivoAccesorioPageViewModel>();
            containerRegistry.RegisterForNavigation<EgresosPage, EgresosPageViewModel>();
            containerRegistry.RegisterForNavigation<EspaciosDeportivoPage, EspaciosDeportivoPageViewModel>();
            containerRegistry.RegisterForNavigation<EventosPage, EventosPageViewModel>();
            containerRegistry.RegisterForNavigation<HorarioPage, HorarioPageViewModel>();
            containerRegistry.RegisterForNavigation<InicialPage, InicialPageViewModel>();
            containerRegistry.RegisterForNavigation<NumeracionPage, NumeracionPageViewModel>();
            containerRegistry.RegisterForNavigation<PagoCabeceraPage, PagoCabeceraPageViewModel>();
            containerRegistry.RegisterForNavigation<PagoDetallePage, PagoDetallePageViewModel>();
            containerRegistry.RegisterForNavigation<TipoDeportivoPage, TipoDeportivoPageViewModel>();
            containerRegistry.RegisterForNavigation<TipoDocumentoPage, TipoDocumentoPageViewModel>();
        }
    }
}
