using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public virtual ICollection<EmpSkill> EmpSkills { get; set; } = new List<EmpSkill>();
}
