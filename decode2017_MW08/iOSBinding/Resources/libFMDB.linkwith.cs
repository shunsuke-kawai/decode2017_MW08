using System;
using ObjCRuntime;

[assembly: LinkWith("libFMDB.a", SmartLink = true, ForceLoad = true)]
