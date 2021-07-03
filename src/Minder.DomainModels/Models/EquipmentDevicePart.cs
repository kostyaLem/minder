using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class EquipmentDevicePart
    {
        public int EquipmentId { get; set; }
        public int DevicePartId { get; set; }

        public virtual DevicePart DevicePart { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
