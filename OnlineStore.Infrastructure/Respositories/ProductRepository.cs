using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository (OnlinestoreContext onlinestoreContext) : base (onlinestoreContext)
        { }
    }
}
