using System;
using CoreLocation;
using MinionMaster.Services;
using System.Linq;

namespace MinionMaster.iOS
{
    public class LocationManager : ILocationManager
    {
        private CLLocationManager locationService;
        Action<double, double> _locationUpdated;

        void LocationUpdated(object sender, CLLocationsUpdatedEventArgs e)
        {
            _locationUpdated.Invoke(e.Locations.First().Coordinate.Latitude, e.Locations.First().Coordinate.Longitude);
        }

        public void StartGettingLocation(Action<double, double> locationUpdated)
        {
            _locationUpdated = locationUpdated;

            locationService = new CLLocationManager();

            locationService.RequestWhenInUseAuthorization();
            locationService.LocationsUpdated += LocationUpdated;
            locationService.StartUpdatingLocation();
        }
    }
}
