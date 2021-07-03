using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class EquipmentsSoftwary
    {
        public int SoftwareId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Software Software { get; set; }
    }
}
