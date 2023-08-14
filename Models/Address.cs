using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Street { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();
}
