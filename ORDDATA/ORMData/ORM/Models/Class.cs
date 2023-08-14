using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? ProfessorId { get; set; }

    public virtual Professor? Professor { get; set; }
}
