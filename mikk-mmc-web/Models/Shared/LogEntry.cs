using System;

namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Represents a log entry from a router device
    /// </summary>
    public class LogEntry : ModelBase
    {
        private string _id;
        private DateTime _timestamp;
        private string _facility;
        private string _topic;
        private string _message;
        private LogSeverity _severity;

        /// <summary>
        /// Gets or sets the identifier of the log entry
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the timestamp of the log entry
        /// </summary>
        public DateTime Timestamp
        {
            get => _timestamp;
            set => SetProperty(ref _timestamp, value);
        }

        /// <summary>
        /// Gets or sets the facility of the log entry
        /// </summary>
        public string Facility
        {
            get => _facility;
            set => SetProperty(ref _facility, value);
        }

        /// <summary>
        /// Gets or sets the topic of the log entry
        /// </summary>
        public string Topic
        {
            get => _topic;
            set => SetProperty(ref _topic, value);
        }

        /// <summary>
        /// Gets or sets the message of the log entry
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        /// <summary>
        /// Gets or sets the severity of the log entry
        /// </summary>
        public LogSeverity Severity
        {
            get => _severity;
            set => SetProperty(ref _severity, value);
        }

        /// <summary>
        /// Gets a CSS class for the log severity
        /// </summary>
        public string SeverityClass
        {
            get
            {
                return Severity switch
                {
                    LogSeverity.Debug => "debug",
                    LogSeverity.Info => "info",
                    LogSeverity.Warning => "warning",
                    LogSeverity.Error => "error",
                    LogSeverity.Critical => "critical",
                    _ => "unknown"
                };
            }
        }
    }
}
