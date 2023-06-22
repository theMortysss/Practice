using System;
using System.Collections.Generic;

namespace Practice.Entitys;

public partial class Supplie
{
    public int Id { get; set; }

    public int? SupplierId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime DateOfSupplie { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
