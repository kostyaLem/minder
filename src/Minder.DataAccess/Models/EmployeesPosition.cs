using System;
using System.Collections.Generic;

#nullable disable

namespace Minder.DataAccess.Models
{
    public partial class EmployeesPosition
    {
        public EmployeesPosition()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public byte[] Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
