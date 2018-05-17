using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Brother.Tests.Common.Logging
{

    public class MpsLoggingConsole : ILoggingService
    {
        private readonly LoggingLevel _loggingLevel;
        private readonly string _scenarioName;
        private readonly IOutputLoggingStream _loggingStream;

        public MpsLoggingConsole(ILoggingServiceSettings loggingServiceSettings ) 
        {
            try
            {
                _loggingLevel = (LoggingLevel)Enum.Parse(typeof(LoggingLevel), loggingServiceSettings.LoggingLevel.ToUpper());
            }
            catch
            {
                _loggingLevel = LoggingLevel.WARNING;
            }
            _scenarioName = string.IsNullOrWhiteSpace(loggingServiceSettings.ScenarioName) ? "(UNKNOWN)" : loggingServiceSettings.ScenarioName;
            _loggingStream = OutputLoggingStreamFactory.Create(loggingServiceSettings.LoggingStreamType);
        }
        public void WriteLog(LoggingLevel level, object message)
        {
            if (IsLoggingEnabled(level) == false) return;
            _loggingStream.WriteLine(string.Format("{0}{1}", PreString(level), message));
        }

        public void WriteLog(LoggingLevel level, string format, params object[] args)
        {
            if (IsLoggingEnabled(level) == false) return;
            var message = string.Format(format, args);
            _loggingStream.WriteLine(string.Format("{0}{1}", PreString(level), message));

        }

        public void WriteLog(LoggingLevel level, object message, Exception exception)
        {
            if (IsLoggingEnabled(level) == false) return;
            var preString = PreString(level);
            _loggingStream.WriteLine(string.Format("{0}{1}", preString, message));
            _loggingStream.WriteLine(string.Format("{0}{1}", preString, exception.StackTrace));
        }

        public bool IsLoggingEnabled(LoggingLevel loggingLevel)
        {
            return loggingLevel >= _loggingLevel;
        }

        public void WriteLogOnMethodEntry(object[] args)
        {
            int skipFrames = 1;
            var loggingService = this;
            try
            {
                var callerFrame = new StackFrame(skipFrames);
                var method = callerFrame.GetMethod();
                var methodName = method.Name;
                var className = method.ReflectedType.Name;

                if (loggingService.IsLoggingEnabled(LoggingLevel.DEBUG))
                {
                    var stringList = new List<string>();
                    foreach (var parameter in method.GetParameters())
                    {
                        if (parameter.IsOut) continue;
                        stringList.Add(string.Format("{0}={1}", parameter.Name, args[stringList.Count]));
                    }
                    var prms = string.Join(",", stringList.ToArray());
                    loggingService.WriteLog(LoggingLevel.DEBUG, "{0}#{1}({2})", className, methodName, prms);
                }
                else if (loggingService.IsLoggingEnabled(LoggingLevel.INFO))
                {
                    loggingService.WriteLog(LoggingLevel.INFO, "{0}#{1}()", className, methodName);
                }

            }
            catch
            {
                // ignored
            }
        }

        private string PreString(LoggingLevel level)
        {
            var nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return string.Format("{0} {1} {2} - ", nowTime, _scenarioName, level);
        }

        public T WriteLogWhenWarningTimeoutExceeds<T>(Func<ILoggingService, T> p, int timeOut, string warningMessageWhenTimeExceed = "too much time", [CallerLineNumber]int lineNumber = 0)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = p(this);
            sw.Stop();
            var elapsedSec = sw.ElapsedMilliseconds / 1000;
            if (elapsedSec >= timeOut)
            {
                var callerFrame = new StackFrame(1);
                var method = callerFrame.GetMethod();
                var methodName = method.Name;
                var className = method.ReflectedType.Name;
                WriteLog(LoggingLevel.WARNING, "{0}#{1}({2}) exectime={3}s {4}",className,methodName,lineNumber, elapsedSec, warningMessageWhenTimeExceed);
            }
            return result;
        }
    }

    public class OutputLoggingStreamFactory
    {
        public static IOutputLoggingStream Create(string loggingOutputType)
        {
            switch ((""+loggingOutputType).ToLower())
            {
                case "nunit":
                    return new NunitOutputLoggingStream();
                case "trace":
                    return new TraceOutputLoggingStream();
                case "console":
                    return new ConsoleOutputLoggingStream();
                case "debug":
                    return new DebugOutputLoggingStream();
                case "auto":
                    // no-break
                default:
#if DEBUG
                    return new TraceOutputLoggingStream();
#else
                    return new ConsoleOutputLoggingStream();
#endif
            }
        }
    }

    public interface IOutputLoggingStream
    {
        void WriteLine(string message);
    }

    public class ConsoleOutputLoggingStream : IOutputLoggingStream
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class DebugOutputLoggingStream : IOutputLoggingStream
    {
        public void WriteLine(string message)
        {
            Debug.WriteLine(message);
        }
    }

    public class TraceOutputLoggingStream : IOutputLoggingStream
    {
        public void WriteLine(string message)
        {
            Trace.WriteLine(message);
        }
    }

    public class NunitOutputLoggingStream : IOutputLoggingStream
    {
        public void WriteLine(string message)
        {
            TestContext.Progress.WriteLine(message);
        }
    }

}
