using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class EmpSkill
{
    public int Empdid { get; set; }

    public int SkillId { get; set; }

    public int ExperienceInYears { get; set; }

    public string SkillLevel { get; set; } = null!;

    public virtual Employee Empd { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
