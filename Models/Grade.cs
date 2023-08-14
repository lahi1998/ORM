using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? GradeValue { get; set; }

    public int? StudentId { get; set; }

    public int? ProfessorId { get; set; }

    public virtual Professor? Professor { get; set; }

    public virtual Student? Student { get; set; }
}
