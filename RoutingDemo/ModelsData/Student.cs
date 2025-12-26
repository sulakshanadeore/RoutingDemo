using System;
using System.Collections.Generic;

namespace RoutingDemo.ModelsData;

public partial class Student
{
    public int RollNo { get; set; }

    public string StudentName { get; set; } = null!;

    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
}
