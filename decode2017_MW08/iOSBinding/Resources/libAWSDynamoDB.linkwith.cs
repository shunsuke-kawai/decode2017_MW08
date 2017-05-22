using System;
using ObjCRuntime;

[assembly: LinkWith ("libAWSDynamoDB.a", SmartLink = true, ForceLoad = true)]
