using System;
using System.Collections.Generic;

namespace OnlineStore.Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int Count { get; set; }

    public decimal TotalPrice { get; set; }

    public int? ProductId { get; set; }

    public int? CustomerId { get; set; }

    public int? SellerId { get; set; }

    public DateTimeOffset? CreatedDate { get; set; }

    public DateTimeOffset? UpdatedDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Seller? Seller { get; set; }
}
