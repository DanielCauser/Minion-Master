using System;
namespace MinionMaster.Services
{
    public interface ILocationManager
    {
        void StartGettingLocation(Action locationUpdated);
    }
}
