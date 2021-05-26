using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class Software
    {
        public Software()
        {
            EquipmentsSoftwaries = new HashSet<EquipmentsSoftwary>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ProductKey { get; set; }
        public float? Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<EquipmentsSoftwary> EquipmentsSoftwaries { get; set; }
    }
}
