using System;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MikroTikMonitor.Models.Dtos
{
    /// <summary>
    /// Represents a MikroTik device registered in MikroTik Cloud for API serialization
    /// </summary>
    public class CloudDeviceDto
    {
        /// <summary>
        /// Gets or sets the unique ID of the device
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the model of the device
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the serial number of the device
        /// </summary>
        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the MAC address of the device
        /// </summary>
        [JsonPropertyName("macAddress")]
        public string MacAddress { get; set; }

        /// <summary>
        /// Gets or sets the public IP address of the device
        /// </summary>
        [JsonPropertyName("publicIpAddress")]
        public string PublicIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the RouterOS version of the device
        /// </summary>
        [JsonPropertyName("routerOsVersion")]
        public string RouterOsVersion { get; set; }

        /// <summary>
        /// Gets or sets whether VPN is enabled for the device
        /// </summary>
        [JsonPropertyName("isVpnEnabled")]
        public bool IsVpnEnabled { get; set; }

        /// <summary>
        /// Gets or sets the status of the device
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets when the device was last seen
        /// </summary>
        [JsonPropertyName("lastSeen")]
        public DateTime LastSeen { get; set; }

        /// <summary>
        /// Gets or sets when the device was last updated
        /// </summary>
        [JsonPropertyName("lastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// Gets or sets the site ID of the device
        /// </summary>
        [JsonPropertyName("siteId")]
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets the site name of the device
        /// </summary>
        [JsonPropertyName("siteName")]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets additional metadata for the device
        /// </summary>
        [JsonPropertyName("metadata")]
        public CloudDeviceMetadataDto Metadata { get; set; }
    }

    /// <summary>
    /// Represents metadata for a MikroTik cloud device for API serialization
    /// </summary>
    public partial class CloudDeviceMetadataDto
    {
        /// <summary>
        /// Gets or sets the latitude of the device location
        /// </summary>
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the device location
        /// </summary>
        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the address of the device location
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the contact person for the device
        /// </summary>
        [JsonPropertyName("contactPerson")]
        public string ContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the contact phone for the device
        /// </summary>
        [JsonPropertyName("contactPhone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the contact email for the device
        /// </summary>
        [JsonPropertyName("contactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the notes for the device
        /// </summary>
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }
    
}

namespace MikroTikMonitor.Models 
{
    using MikroTikMonitor.Models.Dtos;
    
    /// <summary>
    /// Represents a MikroTik device registered in MikroTik Cloud
    /// </summary>
    public class CloudDevice : ModelBase
    {
        private string _id;
        private string _name;
        private string _model;
        private string _serialNumber;
        private string _macAddress;
        private string _publicIpAddress;
        private string _routerOsVersion;
        private bool _isVpnEnabled;
        private string _status;
        private DateTime _lastSeen;
        private DateTime _lastUpdateTime;
        private string _siteId;
        private string _siteName;
        private CloudDeviceMetadata _metadata;

        /// <summary>
        /// Gets or sets the unique ID of the device
        /// </summary>
        public string Id 
        { 
            get => _id; 
            set => SetProperty(ref _id, value); 
        }
        
        /// <summary>
        /// Gets or sets the name of the device
        /// </summary>
        public string Name 
        { 
            get => _name; 
            set => SetProperty(ref _name, value); 
        }
        
        /// <summary>
        /// Gets or sets the model of the device
        /// </summary>
        public string Model 
        { 
            get => _model; 
            set => SetProperty(ref _model, value); 
        }
        
        /// <summary>
        /// Gets or sets the serial number of the device
        /// </summary>
        public string SerialNumber 
        { 
            get => _serialNumber; 
            set => SetProperty(ref _serialNumber, value); 
        }
        
        /// <summary>
        /// Gets or sets the MAC address of the device
        /// </summary>
        public string MacAddress 
        { 
            get => _macAddress; 
            set => SetProperty(ref _macAddress, value); 
        }
        
        /// <summary>
        /// Gets or sets the public IP address of the device
        /// </summary>
        public string PublicIpAddress 
        { 
            get => _publicIpAddress; 
            set => SetProperty(ref _publicIpAddress, value); 
        }
        
        /// <summary>
        /// Gets or sets the RouterOS version of the device
        /// </summary>
        public string RouterOsVersion 
        { 
            get => _routerOsVersion; 
            set => SetProperty(ref _routerOsVersion, value); 
        }
        
        /// <summary>
        /// Gets or sets whether VPN is enabled for the device
        /// </summary>
        public bool IsVpnEnabled 
        { 
            get => _isVpnEnabled; 
            set => SetProperty(ref _isVpnEnabled, value); 
        }
        
        /// <summary>
        /// Gets or sets the status of the device
        /// </summary>
        public string Status 
        { 
            get => _status; 
            set => SetProperty(ref _status, value); 
        }
        
        /// <summary>
        /// Gets or sets when the device was last seen
        /// </summary>
        public DateTime LastSeen 
        { 
            get => _lastSeen; 
            set => SetProperty(ref _lastSeen, value); 
        }
        
        /// <summary>
        /// Gets or sets when the device was last updated
        /// </summary>
        public DateTime LastUpdateTime 
        { 
            get => _lastUpdateTime; 
            set => SetProperty(ref _lastUpdateTime, value); 
        }
        
        /// <summary>
        /// Gets or sets the site ID of the device
        /// </summary>
        public string SiteId 
        { 
            get => _siteId; 
            set => SetProperty(ref _siteId, value); 
        }
        
        /// <summary>
        /// Gets or sets the site name of the device
        /// </summary>
        public string SiteName 
        { 
            get => _siteName; 
            set => SetProperty(ref _siteName, value); 
        }
        
        /// <summary>
        /// Gets or sets additional metadata for the device
        /// </summary>
        public CloudDeviceMetadata Metadata 
        { 
            get => _metadata; 
            set => SetProperty(ref _metadata, value); 
        }
        
        /// <summary>
        /// Creates a new instance of CloudDevice from a DTO
        /// </summary>
        public static CloudDevice FromDto(CloudDeviceDto dto)
        {
            if (dto == null)
                return null;
                
            return new CloudDevice
            {
                Id = dto.Id,
                Name = dto.Name,
                Model = dto.Model,
                SerialNumber = dto.SerialNumber,
                MacAddress = dto.MacAddress,
                PublicIpAddress = dto.PublicIpAddress,
                RouterOsVersion = dto.RouterOsVersion,
                IsVpnEnabled = dto.IsVpnEnabled,
                Status = dto.Status,
                LastSeen = dto.LastSeen,
                LastUpdateTime = dto.LastUpdateTime,
                SiteId = dto.SiteId,
                SiteName = dto.SiteName,
                Metadata = dto.Metadata != null ? CloudDeviceMetadata.FromDto(dto.Metadata) : null
            };
        }
        
        /// <summary>
        /// Converts to a DTO
        /// </summary>
        public CloudDeviceDto ToDto()
        {
            return new CloudDeviceDto
            {
                Id = Id,
                Name = Name,
                Model = Model,
                SerialNumber = SerialNumber,
                MacAddress = MacAddress,
                PublicIpAddress = PublicIpAddress,
                RouterOsVersion = RouterOsVersion,
                IsVpnEnabled = IsVpnEnabled,
                Status = Status,
                LastSeen = LastSeen,
                LastUpdateTime = LastUpdateTime,
                SiteId = SiteId,
                SiteName = SiteName,
                Metadata = Metadata?.ToDto()
            };
        }
    }
    
    /// <summary>
    /// Represents metadata for a MikroTik cloud device
    /// </summary>
    public class CloudDeviceMetadata : ModelBase
    {
        private double? _latitude;
        private double? _longitude;
        private string _address;
        private string _contactPerson;
        private string _contactPhone;
        private string _contactEmail;
        private string _notes;
        
        /// <summary>
        /// Gets or sets the latitude of the device location
        /// </summary>
        public double? Latitude 
        { 
            get => _latitude; 
            set => SetProperty(ref _latitude, value); 
        }
        
        /// <summary>
        /// Gets or sets the longitude of the device location
        /// </summary>
        public double? Longitude 
        { 
            get => _longitude; 
            set => SetProperty(ref _longitude, value); 
        }
        
        /// <summary>
        /// Gets or sets the address of the device location
        /// </summary>
        public string Address 
        { 
            get => _address; 
            set => SetProperty(ref _address, value); 
        }
        
        /// <summary>
        /// Gets or sets the contact person for the device
        /// </summary>
        public string ContactPerson 
        { 
            get => _contactPerson; 
            set => SetProperty(ref _contactPerson, value); 
        }
        
        /// <summary>
        /// Gets or sets the contact phone for the device
        /// </summary>
        public string ContactPhone 
        { 
            get => _contactPhone; 
            set => SetProperty(ref _contactPhone, value); 
        }
        
        /// <summary>
        /// Gets or sets the contact email for the device
        /// </summary>
        public string ContactEmail 
        { 
            get => _contactEmail; 
            set => SetProperty(ref _contactEmail, value); 
        }
        
        /// <summary>
        /// Gets or sets the notes for the device
        /// </summary>
        public string Notes 
        { 
            get => _notes; 
            set => SetProperty(ref _notes, value); 
        }
        
        /// <summary>
        /// Creates a new instance of CloudDeviceMetadata from a DTO
        /// </summary>
        public static CloudDeviceMetadata FromDto(CloudDeviceMetadataDto dto)
        {
            if (dto == null)
                return null;
                
            return new CloudDeviceMetadata
            {
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Address = dto.Address,
                ContactPerson = dto.ContactPerson,
                ContactPhone = dto.ContactPhone,
                ContactEmail = dto.ContactEmail,
                Notes = dto.Notes
            };
        }
        
        /// <summary>
        /// Converts to a DTO
        /// </summary>
        public CloudDeviceMetadataDto ToDto()
        {
            return new CloudDeviceMetadataDto
            {
                Latitude = Latitude,
                Longitude = Longitude,
                Address = Address,
                ContactPerson = ContactPerson,
                ContactPhone = ContactPhone,
                ContactEmail = ContactEmail,
                Notes = Notes
            };
        }
    }
}