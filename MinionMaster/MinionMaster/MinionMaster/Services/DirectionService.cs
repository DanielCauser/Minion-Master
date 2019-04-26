using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace MinionMaster.Services
{
    public class DirectionService : IDirectionService
    {
        readonly Subject<Unit> partnerStatusChangedSubject;
        readonly Subject<Unit> gpsReceivedSubject;
        readonly Subject<double> compassDirectionReceivedSubject;

        public IObservable<Unit> PartnerStatusChanged() => this.partnerStatusChangedSubject;
        public IObservable<Unit> GpsReceived() => this.gpsReceivedSubject;
        public IObservable<double> CompassDirectionReceived() => this.compassDirectionReceivedSubject;

        public DirectionService()
        {
            this.compassDirectionReceivedSubject = new Subject<double>();
            this.gpsReceivedSubject = new Subject<Unit>();
            this.partnerStatusChangedSubject = new Subject<Unit>();
        }

        public Task BrandMe(string brand)
        {
            throw new NotImplementedException();
        }

        public Task SendDirection(double heading)
        {
            throw new NotImplementedException();
        }

        public Task SendGps(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
