namespace OnlineStore.Service.DTOs.Product
{
    public class ProductForUpdateDTo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProductCount { get; set; }
        public int Sold { get; set; }
    }
}
