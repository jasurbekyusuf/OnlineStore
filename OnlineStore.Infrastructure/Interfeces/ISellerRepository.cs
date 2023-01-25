using OnlineStore.Domain.Entities;

namespace OnlineStore.Infrastructure.Interfeces
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task<Seller> GetByEmailAsync(string email);
        Task<Seller> GetByFirstNameAsync(string firstName);
    }
}
