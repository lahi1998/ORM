using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Student
{
    public int PersonId { get; set; }

    public string? StudentNumber { get; set; }

    public int? AverageMark { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual Person Person { get; set; } = null!;
}
