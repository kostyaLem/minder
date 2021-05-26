using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LocationInOffice { get; set; }
        public byte[] Photo { get; set; }
        public string Comment { get; set; }
        public int PositionId { get; set; }

        public virtual EmployeesPosition Position { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
