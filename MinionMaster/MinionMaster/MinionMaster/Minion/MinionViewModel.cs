using System;
using System.Reactive;
using System.Reactive.Subjects;
using MinionMaster.Services;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

namespace MinionMaster.Minion
{
    public class MinionViewModel : ViewModelBase
    {
        private readonly IDirectionService service;
        private readonly ILocationManager _locationManager;

        public MinionViewModel(INavigationService navigationService,
             IDirectionService service,
             ILocationManager locationManager) : base(navigationService)
        {
            _locationManager = locationManager;

            this.service = service;

            this.service.OnCompassDirectionReceived()
                .Subscribe((heading) =>
                {
                    this.Heading = heading.Value;
                });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _locationManager.StartGettingLocation(() =>
            {
                Console.WriteLine("location updated");
            });
        }

        [Reactive] public double Heading { get; set; }
        public ILocationManager LocationManager { get; }
    }
}
