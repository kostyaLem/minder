using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class DeviceMetadata
    {
        public int MetadataId { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
        public virtual Metadata Metadata { get; set; }
    }
}
