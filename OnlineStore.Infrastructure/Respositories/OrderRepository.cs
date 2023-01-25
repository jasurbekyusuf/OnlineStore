using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlinestoreContext onlinestoreContext) : base(onlinestoreContext)
        { }
    }
}
