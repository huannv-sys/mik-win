using System;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents a log entry from a Mikrotik router
    /// </summary>
    public class LogEntry : ModelBase
    {
        private string _id;
        private DateTime _time;
        private string _topic;
        private string _message;
        private LogSeverity _severity;
        private string _facility;
        private int _level;
        private string _sourceIp;
        private string _sourcePort;
        private string _sourceInterface;
        private string _sourceUser;
        private string _destination;
        private bool _markedRead;

        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the time of the log entry
        /// </summary>
        public DateTime Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
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
        /// Gets or sets the facility of the log entry
        /// </summary>
        public string Facility
        {
            get => _facility;
            set => SetProperty(ref _facility, value);
        }

        /// <summary>
        /// Gets or sets the level of the log entry
        /// </summary>
        public int Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        /// <summary>
        /// Gets or sets the source IP address
        /// </summary>
        public string SourceIp
        {
            get => _sourceIp;
            set => SetProperty(ref _sourceIp, value);
        }

        /// <summary>
        /// Gets or sets the source port
        /// </summary>
        public string SourcePort
        {
            get => _sourcePort;
            set => SetProperty(ref _sourcePort, value);
        }

        /// <summary>
        /// Gets or sets the source interface
        /// </summary>
        public string SourceInterface
        {
            get => _sourceInterface;
            set => SetProperty(ref _sourceInterface, value);
        }

        /// <summary>
        /// Gets or sets the source user
        /// </summary>
        public string SourceUser
        {
            get => _sourceUser;
            set => SetProperty(ref _sourceUser, value);
        }

        /// <summary>
        /// Gets or sets the destination
        /// </summary>
        public string Destination
        {
            get => _destination;
            set => SetProperty(ref _destination, value);
        }

        /// <summary>
        /// Gets or sets whether the log entry has been marked as read
        /// </summary>
        public bool MarkedRead
        {
            get => _markedRead;
            set => SetProperty(ref _markedRead, value);
        }

        /// <summary>
        /// Gets the relative time of the log entry (e.g. "2 minutes ago")
        /// </summary>
        public string RelativeTime => GetRelativeTime(Time);

        /// <summary>
        /// Initializes a new instance of the LogEntry class
        /// </summary>
        public LogEntry()
        {
            Id = Guid.NewGuid().ToString();
            Time = DateTime.Now;
            Severity = LogSeverity.Info;
        }

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            return $"[{Time:yyyy-MM-dd HH:mm:ss}] {Topic}: {Message}";
        }

        /// <summary>
        /// Gets a human-readable relative time
        /// </summary>
        /// <param name="time">The time to convert</param>
        /// <returns>A string representing the relative time</returns>
        private string GetRelativeTime(DateTime time)
        {
            var span = DateTime.Now - time;

            if (span.TotalDays > 30)
            {
                return time.ToString("yyyy-MM-dd");
            }
            if (span.TotalDays > 1)
            {
                return $"{span.Days} days ago";
            }
            if (span.TotalHours > 1)
            {
                return $"{(int)span.TotalHours} hours ago";
            }
            if (span.TotalMinutes > 1)
            {
                return $"{(int)span.TotalMinutes} minutes ago";
            }
            
            return span.TotalSeconds >= 5 ? $"{(int)span.TotalSeconds} seconds ago" : "just now";
        }
    }
}