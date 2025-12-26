using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class Employee
{
    public int EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual ICollection<EmpSkill> EmpSkills { get; set; } = new List<EmpSkill>();
}
