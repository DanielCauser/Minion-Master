using System;
namespace MinionMaster.Services
{
    public interface ILocationManager
    {
        void StartGettingLocation(Action<double, double> locationUpdated);
        void StopGettingLocation();
    }
}
