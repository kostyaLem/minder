using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DomainModels.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentDeviceParts = new HashSet<EquipmentDevicePart>();
            EquipmentsSoftwaries = new HashSet<EquipmentsSoftwary>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UsedByEmpolyeeId { get; set; }

        public virtual Employee UsedByEmpolyee { get; set; }
        public virtual ICollection<EquipmentDevicePart> EquipmentDeviceParts { get; set; }
        public virtual ICollection<EquipmentsSoftwary> EquipmentsSoftwaries { get; set; }
    }
}
