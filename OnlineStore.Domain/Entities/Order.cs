using System;
using System.Collections.Generic;

namespace OnlineStore.Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int Count { get; set; }

    public int TotalPrice { get; set; }

    public int CustomerId { get; set; }

    public int SellerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    public virtual Seller Seller { get; set; } = null!;
}
