﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Entitys;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int SupplierId { get; set; }

    public int PackingG { get; set; }

    public int Quantity { get; set; }

    public int ExpirationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<Supplie> Supplies { get; set; } = new List<Supplie>();

    public List<Sale> GetRecentSales(int dayCount)
    {
        return Sales
            .Where(s => DateTime.Now.AddDays(-dayCount) < s.DateOfSale)
            .ToList();
    }
}
