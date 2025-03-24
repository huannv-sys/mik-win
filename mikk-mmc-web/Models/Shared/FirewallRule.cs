using System;

namespace mikk_mmc_web.Models.Shared
{
    /// <summary>
    /// Represents a firewall rule on a router device
    /// </summary>
    public class FirewallRule : ModelBase
    {
        private string _id;
        private string _chain;
        private string _action;
        private string _srcAddress;
        private string _dstAddress;
        private string _protocol;
        private string _srcPort;
        private string _dstPort;
        private string _inInterface;
        private string _outInterface;
        private string _comment;
        private bool _isEnabled;
        private int _order;

        /// <summary>
        /// Gets or sets the identifier of the rule
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the chain of the rule
        /// </summary>
        public string Chain
        {
            get => _chain;
            set => SetProperty(ref _chain, value);
        }

        /// <summary>
        /// Gets or sets the action of the rule
        /// </summary>
        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }

        /// <summary>
        /// Gets or sets the source address of the rule
        /// </summary>
        public string SrcAddress
        {
            get => _srcAddress;
            set => SetProperty(ref _srcAddress, value);
        }

        /// <summary>
        /// Gets or sets the destination address of the rule
        /// </summary>
        public string DstAddress
        {
            get => _dstAddress;
            set => SetProperty(ref _dstAddress, value);
        }

        /// <summary>
        /// Gets or sets the protocol of the rule
        /// </summary>
        public string Protocol
        {
            get => _protocol;
            set => SetProperty(ref _protocol, value);
        }

        /// <summary>
        /// Gets or sets the source port of the rule
        /// </summary>
        public string SrcPort
        {
            get => _srcPort;
            set => SetProperty(ref _srcPort, value);
        }

        /// <summary>
        /// Gets or sets the destination port of the rule
        /// </summary>
        public string DstPort
        {
            get => _dstPort;
            set => SetProperty(ref _dstPort, value);
        }

        /// <summary>
        /// Gets or sets the in interface of the rule
        /// </summary>
        public string InInterface
        {
            get => _inInterface;
            set => SetProperty(ref _inInterface, value);
        }

        /// <summary>
        /// Gets or sets the out interface of the rule
        /// </summary>
        public string OutInterface
        {
            get => _outInterface;
            set => SetProperty(ref _outInterface, value);
        }

        /// <summary>
        /// Gets or sets the comment of the rule
        /// </summary>
        public string Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        /// <summary>
        /// Gets or sets whether the rule is enabled
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        /// <summary>
        /// Gets or sets the order of the rule
        /// </summary>
        public int Order
        {
            get => _order;
            set => SetProperty(ref _order, value);
        }
    }
}
