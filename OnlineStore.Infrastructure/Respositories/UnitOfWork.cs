using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlinestoreContext onlinestoreContext;


        public ISellerRepository Sellers { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IProductRepository Products { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderProductRepository OrderProducts { get; private set; }

        public UnitOfWork(OnlinestoreContext onlinestoreContext)
        {
            this.onlinestoreContext = onlinestoreContext;

            Sellers = new SellerRepository(onlinestoreContext);
            Customers = new CustomerRepository(onlinestoreContext);
            Products = new ProductRepository(onlinestoreContext);
            Orders = new OrderRepository(onlinestoreContext);
            OrderProducts = new OrderProductRepository(onlinestoreContext);
        }

        public void Dispose()
        {
            onlinestoreContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await onlinestoreContext.SaveChangesAsync();
        }
    }
}
