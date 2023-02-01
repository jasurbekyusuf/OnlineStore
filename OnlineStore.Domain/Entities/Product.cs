namespace OnlineStore.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Descriptions { get; set; }

    public decimal Price { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Seller User { get; set; } = null!;
}
