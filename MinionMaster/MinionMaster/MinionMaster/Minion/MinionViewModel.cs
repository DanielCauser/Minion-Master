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

            this.service.OnCompassDirectionReceived()
                .Subscribe((heading) =>
                {
                    this.Heading = heading.Value;
                });
        }

        [Reactive] public double Heading { get; set; }
    }
}
