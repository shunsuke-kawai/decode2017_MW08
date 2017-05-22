using decode2017_MW08.Interfaces;
using System;

namespace decode2017_MW08.UWP.Platforms
{
    class Beacapp_UWP : IBeacapp
    {
        public event EventUpdateCallback eventUpdateCallback;
        public event FireEventCallback fireEventCallback;

        public string GetDeviceID()
        {
            throw new NotImplementedException();
        }

        public BeacappResponceCode InitializeBeacapp(string requestToken, string secretKey)
        {
            throw new NotImplementedException();
        }

        public BeacappResponceCode StartScan()
        {
            throw new NotImplementedException();
        }

        public BeacappResponceCode StopScan()
        {
            throw new NotImplementedException();
        }

        public BeacappResponceCode updateEvent()
        {
            throw new NotImplementedException();
        }
    }
}
