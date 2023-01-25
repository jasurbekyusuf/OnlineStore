using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using OnlineStore.Infrastructure.Interfeces;

namespace OnlineStore.Infrastructure.Respositories
{
    public class SellerRepository : GenericRepository<Seller>, ISellerRepository
    {
        public SellerRepository(OnlinestoreContext onlinestoreContext) : base(onlinestoreContext)
        { }

        public async Task<Seller> GetByEmailAsync(string email)
        {
            return await onlinestoreContext.Sellers.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<Seller> GetByFirstNameAsync(string firstName)
        {
            return await onlinestoreContext.Sellers.FirstOrDefaultAsync(seller => seller.FirstName == firstName);
        }
    }
}
