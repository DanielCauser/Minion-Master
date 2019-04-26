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

        public MinionViewModel(INavigationService navigationService, IDirectionService service) : base(navigationService)
        {
            this.service = service;

            this.service.CompassDirectionReceived()
                .Subscribe((heading) =>
                {
                    this.Heading = heading;
                });
        }

        [Reactive] public double Heading { get; set; }
    }
}
