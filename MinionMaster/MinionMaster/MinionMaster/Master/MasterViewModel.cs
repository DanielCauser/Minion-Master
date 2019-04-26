using System;
using MinionMaster.Contracts;
using MinionMaster.Services;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

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
                    Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
                });
        }

        [Reactive] public Xamarin.Forms.Maps.Position Position { get; set; }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await service.Connect();
        }
    }
}
