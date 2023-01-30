namespace OnlineStore.Service.DTOs.Order
{
    public class OrderForCreationDto
    {
        public int Count { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int SellerId { get; set; }
    }
}
