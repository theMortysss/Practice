using System;
using System.Collections.Generic;

namespace Practice;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? SupplierId { get; set; }

    public int? PackingG { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<Supplie> Supplies { get; set; } = new List<Supplie>();
}
