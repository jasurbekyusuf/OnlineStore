namespace OnlineStore.Service.DTOs.Product
{
    public class ProductForCreationDto
    {
        public int CreatedSellerId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public decimal Price { get; set; }
    }
}
