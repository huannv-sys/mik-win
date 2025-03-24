using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents a firewall rule on a Mikrotik router
    /// </summary>
    public class FirewallRule : INotifyPropertyChanged
    {
        private string _id;
        private string _chain;
        private string _action;
        private string _protocol;
        private string _srcAddress;
        private string _dstAddress;
        private string _srcPort;
        private string _dstPort;
        private string _inInterface;
        private string _outInterface;
        private string _comment;
        private bool _disabled;
        private bool _invalid;
        private bool _dynamic;
        private int _position;

        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the chain
        /// </summary>
        public string Chain
        {
            get => _chain;
            set
            {
                if (_chain != value)
                {
                    _chain = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the action
        /// </summary>
        public string Action
        {
            get => _action;
            set
            {
                if (_action != value)
                {
                    _action = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the protocol
        /// </summary>
        public string Protocol
        {
            get => _protocol;
            set
            {
                if (_protocol != value)
                {
                    _protocol = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the source address
        /// </summary>
        public string SrcAddress
        {
            get => _srcAddress;
            set
            {
                if (_srcAddress != value)
                {
                    _srcAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the destination address
        /// </summary>
        public string DstAddress
        {
            get => _dstAddress;
            set
            {
                if (_dstAddress != value)
                {
                    _dstAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the source port
        /// </summary>
        public string SrcPort
        {
            get => _srcPort;
            set
            {
                if (_srcPort != value)
                {
                    _srcPort = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the destination port
        /// </summary>
        public string DstPort
        {
            get => _dstPort;
            set
            {
                if (_dstPort != value)
                {
                    _dstPort = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the input interface
        /// </summary>
        public string InInterface
        {
            get => _inInterface;
            set
            {
                if (_inInterface != value)
                {
                    _inInterface = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the output interface
        /// </summary>
        public string OutInterface
        {
            get => _outInterface;
            set
            {
                if (_outInterface != value)
                {
                    _outInterface = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the comment
        /// </summary>
        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the rule is disabled
        /// </summary>
        public bool Disabled
        {
            get => _disabled;
            set
            {
                if (_disabled != value)
                {
                    _disabled = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the rule is invalid
        /// </summary>
        public bool Invalid
        {
            get => _invalid;
            set
            {
                if (_invalid != value)
                {
                    _invalid = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the rule is dynamic
        /// </summary>
        public bool Dynamic
        {
            get => _dynamic;
            set
            {
                if (_dynamic != value)
                {
                    _dynamic = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the position
        /// </summary>
        public int Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Event raised when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the FirewallRule class
        /// </summary>
        public FirewallRule()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The name of the property that changed</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns>A string that represents the current object</returns>
        public override string ToString()
        {
            return $"{Chain} {Action} {Protocol} {SrcAddress}:{SrcPort} -> {DstAddress}:{DstPort}";
        }
    }
}