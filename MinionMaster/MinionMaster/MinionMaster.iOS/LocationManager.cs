using System;
using CoreLocation;
using MinionMaster.Services;

namespace MinionMaster.iOS
{
    public class LocationManager : ILocationManager
    {
        private readonly CLLocationManager locationService;
        public LocationManager()
        {
            locationService = new CLLocationManager();
        }

        public void StartGettingLocation()
        {
            locationService.StartUpdatingLocation();
        }
    }
}
