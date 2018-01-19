using System;
using System.Diagnostics;

namespace Brother.Tests.Common.Logging
{

    public class MpsLoggingConsole : ILoggingService
    {
        private readonly LoggingLevel _loggingLevel;
        private readonly string _scenarioName;
        private readonly IOutputLoggingStream _loggingStream;

        public MpsLoggingConsole(ILoggingServiceSettings commandLineSettings ) 
        {
            try
            {
                _loggingLevel = (LoggingLevel)Enum.Parse(typeof(LoggingLevel), commandLineSettings.LoggingLevel.ToUpper());
            }
            catch
            {
                _loggingLevel = LoggingLevel.WARNING;
            }
            _scenarioName = string.IsNullOrWhiteSpace(commandLineSettings.ScenarioName) ? "(UNKNOWN)" : commandLineSettings.ScenarioName;
            _loggingStream = new MpsOutputLoggingStream();
        }
        public void WriteLog(LoggingLevel level, object message)
        {
            if (IsLoggingEnable(level) == false) return;
            _loggingStream.WriteLine(string.Format("{0}{1}", PreString(level), message));
        }

        public void WriteLog(LoggingLevel level, string format, params object[] args)
        {
            if (IsLoggingEnable(level) == false) return;
            var message = string.Format(format, args);
            _loggingStream.WriteLine(string.Format("{0}{1}", PreString(level), message));

        }

        public void WriteLog(LoggingLevel level, object message, Exception exception)
        {
            if (IsLoggingEnable(level) == false) return;
            var preString = PreString(level);
            _loggingStream.WriteLine(string.Format("{0}{1}", preString, message));
            _loggingStream.WriteLine(string.Format("{0}{1}", preString, exception.StackTrace));
        }

        public bool IsLoggingEnable(LoggingLevel loggingLevel)
        {
            return loggingLevel >= _loggingLevel;
        }

        private string PreString(LoggingLevel level)
        {
            var nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return string.Format("{0} {1} {2} - ", nowTime, _scenarioName, level);
        }
    }

    public interface IOutputLoggingStream
    {
        void WriteLine(string message);
    }

    public class MpsOutputLoggingStream : IOutputLoggingStream
    {
        public void WriteLine(string message)
        {
#if DEBUG
            Trace.WriteLine(message);
#else
            Console.WriteLine(message);
#endif 
        }
    }

}
