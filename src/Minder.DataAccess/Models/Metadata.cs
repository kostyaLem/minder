using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class Metadata
    {
        public Metadata()
        {
            DeviceMetadata = new HashSet<DeviceMetadata>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual ICollection<DeviceMetadata> DeviceMetadata { get; set; }
    }
}
