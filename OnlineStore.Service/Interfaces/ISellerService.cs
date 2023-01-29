using OnlineStore.Domain.Entities;
using OnlineStore.Service.DTOs.Seller;

namespace OnlineStore.Service.Interfaces
{
    public interface ISellerService
    {
        Task<Seller> AddSellerAsync(SellerForCreationDto sellerDto);
        Task<IQueryable<Seller>> RetrieveAllSellers();
    }
}
