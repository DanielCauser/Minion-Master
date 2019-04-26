using MinionMaster.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinionMaster.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ILocationManager _locationManager;

        public MainPageViewModel(INavigationService navigationService,
            ILocationManager locationManager)
            : base(navigationService)
        {
            Title = "Main Page";
            _locationManager = locationManager;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // ask permission
            _locationManager.StartGettingLocation((double lat, double lon) =>
            {
                Console.WriteLine("LOCATION UPDATED");
            });
        }
    }
}
