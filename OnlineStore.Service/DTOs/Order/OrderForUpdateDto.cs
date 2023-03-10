namespace OnlineStore.Service.DTOs.Order
{
    public class OrderForUpdateDto
    {
        public int ProductId { get; set; }
        public int Quantities { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
