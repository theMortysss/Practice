using System;
using System.Collections.Generic;

namespace Practice.Entitys;

public partial class Supplier
{
    public int Id { get; set; }
    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public double? DistanceKm { get; set; }

    public decimal? ShippingCoast { get; set; }

    public int? Preference { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<Supplie> Supplies { get; set; } = new List<Supplie>();
}
