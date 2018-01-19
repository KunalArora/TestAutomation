using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Brother.Tests.Common.Logging
{
    public static class LoggingUtil
    {
        public static void WriteLogOnMethodEntry(ILoggingService logging, object[] args, int skipFrames = 2)
        {
            try
            {
                var callerFrame = new StackFrame(skipFrames);
                var method = callerFrame.GetMethod();
                var methodName = method.Name;
                var className = method.ReflectedType.Name;

                if (logging.IsLoggingEnable(LoggingLevel.DEBUG))
                {
                    var stringList = new List<string>();
                    foreach (var parameter in method.GetParameters())
                    {
                        if (parameter.IsOut) continue;
                        stringList.Add(string.Format("{0}={1}", parameter.Name, args[stringList.Count]));
                    }
                    var prms = string.Join(",", stringList.ToArray());
                    logging.WriteLog(LoggingLevel.DEBUG, "{0}#{1}({2})", className, methodName, prms);
                }
                else if (logging.IsLoggingEnable(LoggingLevel.INFO))
                {
                    logging.WriteLog(LoggingLevel.INFO, "{0}#{1}()", className, methodName);
                }

            }
            catch
            {
                // ignored
            }
        }

        public static void LoggingOnMethodEntry(ILoggingService loggingService, object instance, MethodBase method, object[] args)
        {
            try
            {
                var className = instance.GetType().Name;
                var methodName = method.Name;

                if (loggingService.IsLoggingEnable(LoggingLevel.DEBUG))
                {
                    var stringList = new List<string>();
                    foreach (var parameter in method.GetParameters())
                    {
                        //if (parameter.IsOut) continue;
                        stringList.Add(string.Format("{0}={1}", parameter.Name, args[stringList.Count]));
                    }
                    var prms = string.Join(",", stringList.ToArray());
                    loggingService.WriteLog(LoggingLevel.DEBUG, "{0}#{1}({2})", className, methodName, prms);
                }
                else if (loggingService.IsLoggingEnable(LoggingLevel.INFO))
                {
                    loggingService.WriteLog(LoggingLevel.INFO, "{0}#{1}()", className, methodName);
                }

            }
            catch
            {
                // ignored
            }
        }
    }

}
