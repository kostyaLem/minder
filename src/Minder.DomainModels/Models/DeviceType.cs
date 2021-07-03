using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Devices = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
