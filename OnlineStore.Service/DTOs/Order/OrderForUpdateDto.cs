namespace OnlineStore.Service.DTOs.Order
{
    public class OrderForUpdateDto
    {
        public int Count { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
    }
}
