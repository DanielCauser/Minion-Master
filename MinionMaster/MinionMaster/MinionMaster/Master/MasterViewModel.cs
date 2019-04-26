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

        public MasterViewModel(INavigationService navigationService, IDirectionService service) : base(navigationService)
        {
            this.service = service;

            this.service.OnGpsReceived()
                .Subscribe((heading) =>
                {

                });
        }

        [Reactive] public Position Position { get; set; }
    }
}
