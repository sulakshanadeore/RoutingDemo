using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class Subject
{
    public int SubId { get; set; }

    public string SubName { get; set; } = null!;

    public int Marks { get; set; }

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
}
