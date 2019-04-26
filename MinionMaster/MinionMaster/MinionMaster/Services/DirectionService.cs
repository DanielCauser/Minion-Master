using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using MinionMaster.Contracts;

namespace MinionMaster.Services
{
    public class DirectionService : IDirectionService
    {
        //Events
        readonly Subject<Position> onGpsReceivedSubject;
        readonly Subject<CompassReading> onCompassDirectionReceivedSubject;
        public IObservable<Position> OnGpsReceived() => this.onGpsReceivedSubject;
        public IObservable<CompassReading> OnCompassDirectionReceived() => this.onCompassDirectionReceivedSubject;


        //IObservable<CompassReading> GpsReceived =>
        //Observable.Create<CompassReading>(ob => this.conn.On<CompassReading>("CompassDirectionReading")




        public DirectionService()
        {
            //this.onPartnerStatusChangedSubject = new Subject<Unit>();
            this.onCompassDirectionReceivedSubject = new Subject<CompassReading>();
            this.onGpsReceivedSubject = new Subject<Position>();
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

        public IObservable<CompassReading> CompassDirectionReceived()
        {
            throw new NotImplementedException();
        }

        public IObservable<Position> GpsReceived()
        {
            throw new NotImplementedException();
        }

    }
}
