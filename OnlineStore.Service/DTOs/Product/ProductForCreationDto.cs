namespace OnlineStore.Service.DTOs.Product
{
    public class ProductForCreationDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProductCount { get; set; }
    }
}
