using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Professor
{
    public int PersonId { get; set; }

    public double Salary { get; set; }

    public virtual ICollection<Class> Classes { get; } = new List<Class>();

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual Person Person { get; set; } = null!;
}
