using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class StudentSubject
{
    public int SubId { get; set; }

    public int RollNo { get; set; }

    public string ComplexityLevel { get; set; } = null!;

    public int Duration { get; set; }

    public virtual Student RollNoNavigation { get; set; } = null!;

    public virtual Subject Sub { get; set; } = null!;
}
