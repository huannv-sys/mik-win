using System;
using MikroTikMonitor.Models;

namespace MikroTikMonitor.Services
{
    /// <summary>
    /// Interface for logging services
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a debug message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The optional exception</param>
        void Debug(string message, Exception exception = null);
        
        /// <summary>
        /// Logs an info message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The optional exception</param>
        void Info(string message, Exception exception = null);
        
        /// <summary>
        /// Logs a warning message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The optional exception</param>
        void Warning(string message, Exception exception = null);
        
        /// <summary>
        /// Logs an error message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The optional exception</param>
        void Error(string message, Exception exception = null);
        
        /// <summary>
        /// Logs a critical message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The optional exception</param>
        void Critical(string message, Exception exception = null);
        
        /// <summary>
        /// Logs a message with the specified severity
        /// </summary>
        /// <param name="severity">The log severity</param>
        /// <param name="message">The message to log</param>
        /// <param name="exception">The optional exception</param>
        void Log(LogSeverity severity, string message, Exception exception = null);
    }
}