using System;
using System.Reactive;
using System.Threading.Tasks;
using MinionMaster.Contracts;

namespace MinionMaster.Services
{
    public interface IDirectionService
    {
        Task BrandMe(string brand);
        Task SendDirection(double heading);
        Task SendGps(double latitude, double longitude);

        //IObservable<Unit> PartnerStatusChanged();
        IObservable<Position> GpsReceived();
        //IObservable<double> CompassDirectionReceived();
    }
}
