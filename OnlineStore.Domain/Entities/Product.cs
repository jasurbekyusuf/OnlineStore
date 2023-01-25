using System;
using System.Collections.Generic;

namespace OnlineStore.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public int ProductCount { get; set; }

    public int Sold { get; set; }

    public int SellerId { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset UpdatedDate { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    public virtual Seller Seller { get; set; } = null!;
}
