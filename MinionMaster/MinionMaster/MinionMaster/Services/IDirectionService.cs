using System;
using System.Reactive;
using System.Threading.Tasks;

namespace MinionMaster.Services
{
    public interface IDirectionService
    {
        Task BrandMe(string brand);
        Task SendDirection(double heading);
        Task SendGps(double latitude, double longitude);

        IObservable<Unit> PartnerStatusChanged();
        IObservable<Unit> GpsReceived();
        IObservable<double> CompassDirectionReceived();
    }
}
