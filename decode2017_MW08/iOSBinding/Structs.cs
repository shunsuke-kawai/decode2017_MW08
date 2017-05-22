using System;
using ObjCRuntime;

namespace BeacappLibrary
{
    [Native]
    public enum JBCPCode : uint
    {
        Success = 0,
        InvalidActivationKey = 1000,
        NotInitializeYet = 1001,
        DBError = 1002,
        NetworkError = 1003,
        AccessCodeExpired = 1004,
        NotSupportedBlutooth = 1005,
        InvalidSDKVersion = 1006,
        NeedsDelegateSet = 1007,
        InvalidBackgroundRunning = 1008,
        InvalidData = 1009,
        CannotStartLocation = 1010,
        AWSError = 1011,
        AlreadyScanning = 1012,
        UnKnownError = 9999
    }

    [Native]
    public enum JBCPEventSchedule : long
    {
        Fast,
        Default,
        Long
    }
}

