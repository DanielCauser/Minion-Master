using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MinionMaster.Contracts;
using MinionMaster.Services;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;
using Xamarin.Forms;

namespace MinionMaster.Master
{
    public class MasterViewModel : ViewModelBase
    {
        private readonly IDirectionService service;

        public MasterViewModel(INavigationService navigationService, IDirectionService service)
        {
            this.service = service;

            this.service.OnGpsReceived()
                .Subscribe((position) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Locations.Clear();
                        Locations.Add(new Location() { Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude) });
                    });
                });
        }

        [Reactive] public ObservableCollection<Location> Locations { get; set; } = new ObservableCollection<Location>();


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await service.Connect();
        }
    }

    public class Location
    {
        public Xamarin.Forms.Maps.Position Position { get; set; }
    }
}
