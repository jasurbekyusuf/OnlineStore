

using OnlineStore.Domain.Entities;

namespace OnlineStore.Service.DTOs.Seller
{
    public class SellerForSelectDTo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual List<Order> Orders { get; } = new List<Order>();
        public virtual List<Product> Products { get; } = new List<Product>();
    }
}
