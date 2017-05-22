using System;
using ObjCRuntime;

[assembly: LinkWith("libBeacappSDKforiOS.a", LinkerFlags = "-lz -lsqlite3.0 -ObjC", SmartLink = true, ForceLoad = true)]
