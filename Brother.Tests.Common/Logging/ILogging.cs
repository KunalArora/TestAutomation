﻿using System;

namespace Brother.Tests.Common.Logging
{
    public enum LoggingLevel
    {
        INFO=0,
        DEBUG,
        WARNING,
        FAILURE
    }
    public interface ILogging
    {
        /// <summary>
        /// Log a message object 
        /// </summary>
        /// <param name="level">message log level.</param>
        /// <param name="message">The message object to log.</param>
        /// 
        void WriteLog(LoggingLevel level, object message);

        /// <summary>
        /// Log a message object 
        /// the stack trace of the <see cref="Exception"/> passed
        /// as a parameter.
        /// </summary>
        /// <param name="level">message log level.</param>
        /// <param name="message">The message object to log.</param>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        void WriteLog(LoggingLevel level, object message, Exception exception);

        /// <summary>
        /// Logs a formatted message string .
        /// </summary>
        /// <param name="level">message log level.</param>
        /// <param name="format">A String containing zero or more format items</param>
        /// <param name="args">An Object array containing zero or more objects to format</param>
        void WriteLog(LoggingLevel level, string format, params object[] args);

    }
}
