using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class Department
{
    public int DeptId { get; set; }

    public string Dname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
