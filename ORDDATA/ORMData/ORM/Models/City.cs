using System;
using System.Collections.Generic;

namespace ORM.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? PostalCode { get; set; }

    public int? CountryId { get; set; }

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();

    public virtual Country? Country { get; set; }
}
