using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
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
        //Observable.Create<CompassReading>(ob => this.conn.On<CompassReading>("CompassDirectionReading"))

        private HubConnection connection;

        public DirectionService()
        {
            //this.onPartnerStatusChangedSubject = new Subject<Unit>();
            this.onCompassDirectionReceivedSubject = new Subject<CompassReading>();
            this.onGpsReceivedSubject = new Subject<Position>();

            connection = new HubConnectionBuilder()
                .WithUrl("https://minions.azurewebsites.net/main")
                .Build();
        }

        public async Task Connect () {
            
            connection.On<Position>("GpsReceived", (position) =>
            {
                onGpsReceivedSubject.OnNext(position);
            });

            connection.On<CompassReading>("CompassDirectionReceived", (heading) =>
            {
                onCompassDirectionReceivedSubject.OnNext(heading);
            });

            await connection.StartAsync();
        }

        public async Task BrandMe(string brand)
        {
            await connection.InvokeAsync("BrandMe", brand);
        }

        public async Task SendDirection(double heading)
        {
            await connection.InvokeAsync("SendDirection", new CompassReading
            {
                Value = heading
            });
        }

        public async Task SendGps(double latitude, double longitude)
        {
            await connection.InvokeAsync("SendGps", new Position
            {
                Latitude = latitude,
                Longitude = longitude
            });
        }

        //public async IObservable<CompassReading> CompassDirectionReceived()
        //{
        //    throw new NotImplementedException();
        //}

        //public async IObservable<Position> GpsReceived()
        //{
        //    throw new NotImplementedException();
        //}

    }
}