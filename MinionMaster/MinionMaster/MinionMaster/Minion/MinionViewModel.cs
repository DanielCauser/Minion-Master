using System;
using System.Reactive;
using System.Reactive.Subjects;
using MinionMaster.Services;
using Prism.Navigation;

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

                });
        }
    }
}
