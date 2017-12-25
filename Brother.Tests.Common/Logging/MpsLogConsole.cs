using System;
using System.Diagnostics;

namespace Brother.Tests.Common.Logging
{

    public class MpsLogConsole : ILogging
    {
        private readonly LoggingLevel _level;
        private readonly string _scenarioName;
        private readonly IOutputLoggingStream _loggingStream;

        public MpsLogConsole(ICommandLineSettings commandLineSettings ) 
        {
            try
            {
                _level = (LoggingLevel)Enum.Parse(typeof(LoggingLevel), commandLineSettings.LoggingLevel.ToUpper());
            }
            catch
            {
                _level = LoggingLevel.WARNING;
            }
            _scenarioName = string.IsNullOrWhiteSpace(commandLineSettings.ScenarioName) ? "(UNKNOWN)" : commandLineSettings.ScenarioName;
            _loggingStream = new MpsOutputLoggingStream();
        }
        public void WriteLog(LoggingLevel level, object message)
        {
            if (IsLogging(level) == false) return;
            _loggingStream.WriteLine(string.Format("{0}{1}", PreString(), message));
        }

        public void WriteLog(LoggingLevel level, string format, params object[] args)
        {
            if (IsLogging(level) == false) return;
            var message = string.Format(format, args);
            _loggingStream.WriteLine(string.Format("{0}{1}", PreString(), message));

        }

        public void WriteLog(LoggingLevel level, object message, Exception exception)
        {
            if (IsLogging(level) == false) return;
            var preString = PreString();
            _loggingStream.WriteLine(string.Format("{0}{1}", preString, message));
            _loggingStream.WriteLine(string.Format("{0}{1}", preString, exception.StackTrace));
        }

        private bool IsLogging(LoggingLevel level)
        {
            return level >= _level;
        }

        private string PreString()
        {
            var nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.FFF");
            return string.Format("{0} {1} {2} - ", nowTime, _scenarioName, _level);
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
