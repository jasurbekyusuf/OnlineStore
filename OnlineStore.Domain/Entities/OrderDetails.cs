using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; } 

        public int SellerId { get; set; }
        
        public string SellerName { get; set;}

        public int ProductId { get; set; }
        public string ProductName { get; set;}

        public decimal ProductPrice { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
