namespace OnlineStore.Service.DTOs.Order
{
    public class OrderForCreationDto
    {
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? SellerId { get; set; }
        public int Count { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
