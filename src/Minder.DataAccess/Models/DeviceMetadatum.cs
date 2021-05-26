using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class DeviceMetadatum
    {
        public int MetadataId { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; }
        public virtual Metadatum Metadata { get; set; }
    }
}
