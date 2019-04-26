using System;
using MinionMaster.Services;
using Prism.Navigation;

namespace MinionMaster.Master
{
    public class MasterViewModel : ViewModelBase
    {
        private readonly IDirectionService service;

        public MasterViewModel(INavigationService navigationService, IDirectionService service) : base(navigationService)
        {
            this.service = service;

            this.service.GpsReceived()
                .Subscribe((heading) =>
                {

                });
        }
    }
}
