using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace MikroTikMonitor.Models.Dtos
{
    /// <summary>
    /// Represents a VPN user in MikroTik Cloud for API serialization
    /// </summary>
    public class CloudVpnUserDto
    {
        /// <summary>
        /// Gets or sets the unique ID of the VPN user
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Gets or sets the username of the VPN user
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }
        
        /// <summary>
        /// Gets or sets the email of the VPN user
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        /// <summary>
        /// Gets or sets the status of the VPN user
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        /// <summary>
        /// Gets or sets when the VPN user was created
        /// </summary>
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
        
        /// <summary>
        /// Gets or sets when the VPN user was last active
        /// </summary>
        [JsonPropertyName("lastActive")]
        public DateTime? LastActive { get; set; }
        
        /// <summary>
        /// Gets or sets whether the VPN user is disabled
        /// </summary>
        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }
        
        /// <summary>
        /// Gets or sets the comment for the VPN user
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
        
        /// <summary>
        /// Gets or sets the password for the VPN user (only used for creation, not returned in GET responses)
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        /// <summary>
        /// Gets or sets the full name for the VPN user
        /// </summary>
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        /// <summary>
        /// Gets or sets whether the VPN user is active
        /// </summary>
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Gets or sets the expiration date for the VPN user
        /// </summary>
        [JsonPropertyName("expirationDate")]
        public DateTime? ExpirationDate { get; set; }
        
        /// <summary>
        /// Gets or sets the device ID the VPN user is associated with
        /// </summary>
        [JsonPropertyName("deviceId")]
        public string DeviceId { get; set; }
        
        /// <summary>
        /// Gets or sets when the VPN user was created
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets when the VPN user was last updated
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets when the VPN user last logged in
        /// </summary>
        [JsonPropertyName("lastLoginAt")]
        public DateTime? LastLoginAt { get; set; }
        
        /// <summary>
        /// Gets or sets whether the VPN user is connected
        /// </summary>
        [JsonPropertyName("isConnected")]
        public bool IsConnected { get; set; }
        
        /// <summary>
        /// Gets or sets the connection info for the VPN user
        /// </summary>
        [JsonPropertyName("connectionInfo")]
        public string ConnectionInfo { get; set; }
        
        /// <summary>
        /// Gets or sets notes for the VPN user
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        
        /// <summary>
        /// Gets or sets tags for the VPN user
        /// </summary>
        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }
    }
    
}

namespace MikroTikMonitor.Models
{
    using MikroTikMonitor.Models.Dtos;
    
    /// <summary>
    /// Represents a VPN user in MikroTik Cloud
    /// </summary>
    public class CloudVpnUser : ModelBase
    {
        private string _id;
        private string _username;
        private string _email;
        private string _status;
        private DateTime _createdOn;
        private DateTime? _lastActive;
        private bool _disabled;
        private string _comment;
        private string _password;
        private string _fullName;
        private bool _isActive;
        private DateTime? _expirationDate;
        private string _deviceId;
        private DateTime _createdAt;
        private DateTime _updatedAt;
        private DateTime? _lastLoginAt;
        private bool _isConnected;
        private string _connectionInfo;
        private string _notes;
        private string[] _tags;

        /// <summary>
        /// Gets or sets the unique ID of the VPN user
        /// </summary>
        public string Id 
        { 
            get => _id; 
            set => SetProperty(ref _id, value); 
        }
        
        /// <summary>
        /// Gets or sets the username of the VPN user
        /// </summary>
        public string Username 
        { 
            get => _username; 
            set => SetProperty(ref _username, value); 
        }
        
        /// <summary>
        /// Gets or sets the email of the VPN user
        /// </summary>
        public string Email 
        { 
            get => _email; 
            set => SetProperty(ref _email, value); 
        }
        
        /// <summary>
        /// Gets or sets the status of the VPN user
        /// </summary>
        public string Status 
        { 
            get => _status; 
            set => SetProperty(ref _status, value); 
        }
        
        /// <summary>
        /// Gets or sets when the VPN user was created
        /// </summary>
        public DateTime CreatedOn 
        { 
            get => _createdOn; 
            set => SetProperty(ref _createdOn, value); 
        }
        
        /// <summary>
        /// Gets or sets when the VPN user was last active
        /// </summary>
        public DateTime? LastActive 
        { 
            get => _lastActive; 
            set => SetProperty(ref _lastActive, value); 
        }
        
        /// <summary>
        /// Gets or sets whether the VPN user is disabled
        /// </summary>
        public bool Disabled 
        { 
            get => _disabled; 
            set => SetProperty(ref _disabled, value); 
        }
        
        /// <summary>
        /// Gets or sets the comment for the VPN user
        /// </summary>
        public string Comment 
        { 
            get => _comment; 
            set => SetProperty(ref _comment, value); 
        }
        
        /// <summary>
        /// Gets or sets the password for the VPN user (only used for creation, not returned in GET responses)
        /// </summary>
        public string Password 
        { 
            get => _password; 
            set => SetProperty(ref _password, value); 
        }
        
        /// <summary>
        /// Gets or sets the full name for the VPN user
        /// </summary>
        public string FullName 
        { 
            get => _fullName; 
            set => SetProperty(ref _fullName, value); 
        }
        
        /// <summary>
        /// Gets or sets whether the VPN user is active
        /// </summary>
        public bool IsActive 
        { 
            get => _isActive; 
            set => SetProperty(ref _isActive, value); 
        }
        
        /// <summary>
        /// Gets or sets the expiration date for the VPN user
        /// </summary>
        public DateTime? ExpirationDate 
        { 
            get => _expirationDate; 
            set => SetProperty(ref _expirationDate, value); 
        }
        
        /// <summary>
        /// Gets or sets the device ID the VPN user is associated with
        /// </summary>
        public string DeviceId 
        { 
            get => _deviceId; 
            set => SetProperty(ref _deviceId, value); 
        }
        
        /// <summary>
        /// Gets or sets when the VPN user was created
        /// </summary>
        public DateTime CreatedAt 
        { 
            get => _createdAt; 
            set => SetProperty(ref _createdAt, value); 
        }
        
        /// <summary>
        /// Gets or sets when the VPN user was last updated
        /// </summary>
        public DateTime UpdatedAt 
        { 
            get => _updatedAt; 
            set => SetProperty(ref _updatedAt, value); 
        }
        
        /// <summary>
        /// Gets or sets when the VPN user last logged in
        /// </summary>
        public DateTime? LastLoginAt 
        { 
            get => _lastLoginAt; 
            set => SetProperty(ref _lastLoginAt, value); 
        }
        
        /// <summary>
        /// Gets or sets whether the VPN user is connected
        /// </summary>
        public bool IsConnected 
        { 
            get => _isConnected; 
            set => SetProperty(ref _isConnected, value); 
        }
        
        /// <summary>
        /// Gets or sets the connection info for the VPN user
        /// </summary>
        public string ConnectionInfo 
        { 
            get => _connectionInfo; 
            set => SetProperty(ref _connectionInfo, value); 
        }
        
        /// <summary>
        /// Gets or sets notes for the VPN user
        /// </summary>
        public string Notes 
        { 
            get => _notes; 
            set => SetProperty(ref _notes, value); 
        }
        
        /// <summary>
        /// Gets or sets tags for the VPN user
        /// </summary>
        public string[] Tags 
        { 
            get => _tags; 
            set => SetProperty(ref _tags, value); 
        }
        
        /// <summary>
        /// Creates a new instance of CloudVpnUser from a DTO
        /// </summary>
        public static CloudVpnUser FromDto(CloudVpnUserDto dto)
        {
            if (dto == null)
                return null;
                
            return new CloudVpnUser
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                Status = dto.Status,
                CreatedOn = dto.CreatedOn,
                LastActive = dto.LastActive,
                Disabled = dto.Disabled,
                Comment = dto.Comment,
                Password = dto.Password,
                FullName = dto.FullName,
                IsActive = dto.IsActive,
                ExpirationDate = dto.ExpirationDate,
                DeviceId = dto.DeviceId,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                LastLoginAt = dto.LastLoginAt,
                IsConnected = dto.IsConnected,
                ConnectionInfo = dto.ConnectionInfo,
                Notes = dto.Notes,
                Tags = dto.Tags
            };
        }
        
        /// <summary>
        /// Converts to a DTO
        /// </summary>
        public CloudVpnUserDto ToDto()
        {
            return new CloudVpnUserDto
            {
                Id = Id,
                Username = Username,
                Email = Email,
                Status = Status,
                CreatedOn = CreatedOn,
                LastActive = LastActive,
                Disabled = Disabled,
                Comment = Comment,
                Password = Password,
                FullName = FullName,
                IsActive = IsActive,
                ExpirationDate = ExpirationDate,
                DeviceId = DeviceId,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                LastLoginAt = LastLoginAt,
                IsConnected = IsConnected,
                ConnectionInfo = ConnectionInfo,
                Notes = Notes,
                Tags = Tags
            };
        }
    }
}