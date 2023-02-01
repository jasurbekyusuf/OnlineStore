using System;
using System.Collections.Generic;

namespace OnlineStore.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Descriptions { get; set; }

    public decimal Price { get; set; }

    public int CreatedSellerId { get; set; }

    public virtual Seller CreatedSeller { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
