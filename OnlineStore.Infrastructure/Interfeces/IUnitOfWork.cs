namespace OnlineStore.Infrastructure.Interfeces
{
    public interface IUnitOfWork : IDisposable
    {
        public ISellerRepository Sellers { get; }
        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }
        Task SaveChangesAsync();
    }
}
