using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class DevicePart
    {
        public DevicePart()
        {
            EquipmentDeviceParts = new HashSet<EquipmentDevicePart>();
            InverseParentDevicePart = new HashSet<DevicePart>();
        }

        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int? ParentDevicePartId { get; set; }

        public virtual Device Device { get; set; }
        public virtual DevicePart ParentDevicePart { get; set; }
        public virtual ICollection<EquipmentDevicePart> EquipmentDeviceParts { get; set; }
        public virtual ICollection<DevicePart> InverseParentDevicePart { get; set; }
    }
}
