using System;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MikroTikMonitor.Models.Dtos
{
    /// <summary>
    /// Represents a site in MikroTik Cloud for API serialization
    /// </summary>
    public class CloudSiteDto
    {
        /// <summary>
        /// Gets or sets the unique ID of the site
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the site
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the site
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address of the site
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the site location
        /// </summary>
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the site location
        /// </summary>
        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the contact person for the site
        /// </summary>
        [JsonPropertyName("contactPerson")]
        public string ContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the contact phone for the site
        /// </summary>
        [JsonPropertyName("contactPhone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the contact email for the site
        /// </summary>
        [JsonPropertyName("contactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets when the site was created
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets when the site was last updated
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the number of devices at the site
        /// </summary>
        [JsonPropertyName("deviceCount")]
        public int DeviceCount { get; set; }

        /// <summary>
        /// Gets or sets the number of online devices at the site
        /// </summary>
        [JsonPropertyName("onlineDeviceCount")]
        public int OnlineDeviceCount { get; set; }

        /// <summary>
        /// Gets the percentage of online devices at the site
        /// </summary>
        public double OnlinePercentage => DeviceCount > 0 ? (double)OnlineDeviceCount / DeviceCount * 100 : 0;

        /// <summary>
        /// Gets or sets the status of the site based on online device percentage
        /// </summary>
        public string Status
        {
            get
            {
                if (DeviceCount == 0)
                    return "Empty";
                    
                if (OnlinePercentage == 100)
                    return "All Online";
                    
                if (OnlinePercentage >= 75)
                    return "Mostly Online";
                    
                if (OnlinePercentage >= 50)
                    return "Partially Online";
                    
                if (OnlinePercentage > 0)
                    return "Mostly Offline";
                    
                return "All Offline";
            }
        }
    }
    
}

namespace MikroTikMonitor.Models
{
    using MikroTikMonitor.Models.Dtos;
    
    /// <summary>
    /// Represents a site in MikroTik Cloud
    /// </summary>
    public class CloudSite : ModelBase
    {
        private string _id;
        private string _name;
        private string _description;
        private string _address;
        private double? _latitude;
        private double? _longitude;
        private string _contactPerson;
        private string _contactPhone;
        private string _contactEmail;
        private DateTime _createdAt;
        private DateTime _updatedAt;
        private int _deviceCount;
        private int _onlineDeviceCount;
        
        /// <summary>
        /// Gets or sets the unique ID of the site
        /// </summary>
        public string Id 
        { 
            get => _id; 
            set => SetProperty(ref _id, value); 
        }
        
        /// <summary>
        /// Gets or sets the name of the site
        /// </summary>
        public string Name 
        { 
            get => _name; 
            set => SetProperty(ref _name, value); 
        }
        
        /// <summary>
        /// Gets or sets the description of the site
        /// </summary>
        public string Description 
        { 
            get => _description; 
            set => SetProperty(ref _description, value); 
        }
        
        /// <summary>
        /// Gets or sets the address of the site
        /// </summary>
        public string Address 
        { 
            get => _address; 
            set => SetProperty(ref _address, value); 
        }
        
        /// <summary>
        /// Gets or sets the latitude of the site location
        /// </summary>
        public double? Latitude 
        { 
            get => _latitude; 
            set => SetProperty(ref _latitude, value); 
        }
        
        /// <summary>
        /// Gets or sets the longitude of the site location
        /// </summary>
        public double? Longitude 
        { 
            get => _longitude; 
            set => SetProperty(ref _longitude, value); 
        }
        
        /// <summary>
        /// Gets or sets the contact person for the site
        /// </summary>
        public string ContactPerson 
        { 
            get => _contactPerson; 
            set => SetProperty(ref _contactPerson, value); 
        }
        
        /// <summary>
        /// Gets or sets the contact phone for the site
        /// </summary>
        public string ContactPhone 
        { 
            get => _contactPhone; 
            set => SetProperty(ref _contactPhone, value); 
        }
        
        /// <summary>
        /// Gets or sets the contact email for the site
        /// </summary>
        public string ContactEmail 
        { 
            get => _contactEmail; 
            set => SetProperty(ref _contactEmail, value); 
        }
        
        /// <summary>
        /// Gets or sets when the site was created
        /// </summary>
        public DateTime CreatedAt 
        { 
            get => _createdAt; 
            set => SetProperty(ref _createdAt, value); 
        }
        
        /// <summary>
        /// Gets or sets when the site was last updated
        /// </summary>
        public DateTime UpdatedAt 
        { 
            get => _updatedAt; 
            set => SetProperty(ref _updatedAt, value); 
        }
        
        /// <summary>
        /// Gets or sets the number of devices at the site
        /// </summary>
        public int DeviceCount 
        { 
            get => _deviceCount; 
            set => SetProperty(ref _deviceCount, value); 
        }
        
        /// <summary>
        /// Gets or sets the number of online devices at the site
        /// </summary>
        public int OnlineDeviceCount 
        { 
            get => _onlineDeviceCount; 
            set => SetProperty(ref _onlineDeviceCount, value); 
        }
        
        /// <summary>
        /// Gets the percentage of online devices at the site
        /// </summary>
        public double OnlinePercentage => DeviceCount > 0 ? (double)OnlineDeviceCount / DeviceCount * 100 : 0;
        
        /// <summary>
        /// Gets the status of the site based on online device percentage
        /// </summary>
        public string Status
        {
            get
            {
                if (DeviceCount == 0)
                    return "Empty";
                    
                if (OnlinePercentage == 100)
                    return "All Online";
                    
                if (OnlinePercentage >= 75)
                    return "Mostly Online";
                    
                if (OnlinePercentage >= 50)
                    return "Partially Online";
                    
                if (OnlinePercentage > 0)
                    return "Mostly Offline";
                    
                return "All Offline";
            }
        }
        
        /// <summary>
        /// Creates a new instance of CloudSite from a DTO
        /// </summary>
        public static CloudSite FromDto(CloudSiteDto dto)
        {
            if (dto == null)
                return null;
                
            return new CloudSite
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Address = dto.Address,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                ContactPerson = dto.ContactPerson,
                ContactPhone = dto.ContactPhone,
                ContactEmail = dto.ContactEmail,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                DeviceCount = dto.DeviceCount,
                OnlineDeviceCount = dto.OnlineDeviceCount
            };
        }
        
        /// <summary>
        /// Converts to a DTO
        /// </summary>
        public CloudSiteDto ToDto()
        {
            return new CloudSiteDto
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Address = Address,
                Latitude = Latitude,
                Longitude = Longitude,
                ContactPerson = ContactPerson,
                ContactPhone = ContactPhone,
                ContactEmail = ContactEmail,
                CreatedAt = CreatedAt,
                UpdatedAt = UpdatedAt,
                DeviceCount = DeviceCount,
                OnlineDeviceCount = OnlineDeviceCount
            };
        }
    }
}