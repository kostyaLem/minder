using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class Device
    {
        public Device()
        {
            DeviceMetadata = new HashSet<DeviceMetadata>();
            DeviceParts = new HashSet<DevicePart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; }
        public virtual ICollection<DeviceMetadata> DeviceMetadata { get; set; }
        public virtual ICollection<DevicePart> DeviceParts { get; set; }
    }
}
