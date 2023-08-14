using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<City> Cities { get; } = new List<City>();
}
