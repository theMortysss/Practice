using System;
using System.Collections.Generic;

namespace Practice.Entitys;

public partial class Sale
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? DateOfSale { get; set; }

    public virtual Product? Product { get; set; }
}
