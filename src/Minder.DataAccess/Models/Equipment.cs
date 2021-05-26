using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentDeviceParts = new HashSet<EquipmentDevicePart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsUsed { get; set; }

        public virtual ICollection<EquipmentDevicePart> EquipmentDeviceParts { get; set; }
    }
}
