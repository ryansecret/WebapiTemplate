using System;
using System.Collections.Generic;
using LibLog.Example.Library.Logging;
using Microsoft.Practices.ServiceLocation;

namespace Ryan.Core.Log
{
    public static class LogExtenstion
    {
        public static void LogError(this Exception exception)
        {
            ServiceLocator.Current.GetInstance<ILog>("Error").Error(exception.ToString);
        }

        public static void LogInfo(this string info)
        {
            ServiceLocator.Current.GetInstance<ILog>("Info").Info(info);
        }
    }


   
    public struct LogInfo
    {
        public LogLevel LogLevel;
        public string Message;
    }
}
