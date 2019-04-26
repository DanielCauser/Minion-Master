using System;
using CoreLocation;
using MinionMaster.Services;

namespace MinionMaster.iOS
{
    public class LocationManager : ILocationManager
    {
        private CLLocationManager locationService;
        Action _locationUpdated;

        void LocationUpdated(object sender, EventArgs a)
        {
            _locationUpdated.Invoke();
        }

        public void StartGettingLocation(Action locationUpdated)
        {
            _locationUpdated = locationUpdated;

            locationService = new CLLocationManager();

            locationService.RequestWhenInUseAuthorization();
            locationService.UpdatedLocation += LocationUpdated;
            locationService.StartUpdatingLocation();
        }
    }
}
