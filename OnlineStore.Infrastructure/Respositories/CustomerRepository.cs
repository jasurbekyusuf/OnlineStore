using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OnlinestoreContext onlinestoreContext) : base(onlinestoreContext) 
        { }
    }
}
